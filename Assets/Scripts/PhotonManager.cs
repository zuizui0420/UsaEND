using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhotonManager : Photon.MonoBehaviour
{
	public int test;
	//string [] userName = new string[4];
	string userName = "ユーザ0";
	string userId = "user0";

	[SerializeField]
	GameObject[] players = new GameObject[2];

	public PhotonPlayer photonPlayer;
	public int actID = -1;
	void Awake()
	{
		
		//シーン間を引き継ぐ
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
		test = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//ロビー接続
	public void ConnectPhoton()
	{
		PhotonNetwork.ConnectUsingSettings("v1.0");
	}

	//ロビーに入った時に呼び出される
	void OnJoinedLobby()
	{
		Debug.Log("PhotonManager OnJoinedLobby");
		//ボタンを押せるようにする
		GameObject.Find("CreateRoomBtn").GetComponent<Button>().interactable = true;
		GameObject.Find("EnterRoomBtn").GetComponent<Button>().interactable = true;
		test = 1;
	}

	//ルーム一覧が取れると
	void OnReceivedRoomListUpdate()
	{
		//ルーム一覧を取る
		RoomInfo[] rooms = PhotonNetwork.GetRoomList();
		if (rooms.Length == 0)
		{
			Debug.Log("ルームが一つもありません");
		}
		else
		{
			//ルームが1件以上ある時ループでRoomInfo情報をログ出力
			for (int i = 0; i < rooms.Length; i++)
			{
				Debug.Log("RoomName:" + rooms[i].name);
				Debug.Log("userName:" + rooms[i].customProperties["userName"]);
				Debug.Log("userId:" + rooms[i].customProperties["userId"]);
				GameObject.Find("StatusText").GetComponent<Text>().text = rooms[i].name;
			}
		}
	}

		//ルーム作成
		public void CreateRoom()
	{
		actID = 0;

		photonPlayer = new PhotonPlayer(false, actID, userName);

	
		//string userName = "ユーザ1";
		//string userId = "user1";
		//userName[0] = "ユーザ1";
		PhotonNetwork.autoCleanUpPlayerObjects = false;

		//カスタムプロパティ
		ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
		customProp.Add("userName", userName); //ユーザ名
		customProp.Add("userId", userId); //ユーザID
		PhotonNetwork.SetPlayerCustomProperties(customProp);

		RoomOptions roomOptions = new RoomOptions();
		roomOptions.customRoomProperties = customProp;
		//ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
		roomOptions.customRoomPropertiesForLobby = new string[] { "userName", "userId" };
		roomOptions.maxPlayers = 2; //部屋の最大人数
		roomOptions.isOpen = true; //入室許可する
		roomOptions.isVisible = true; //ロビーから見えるようにする
									  //userIdが名前のルームがなければ作って入室、あれば普通に入室する。
		PhotonNetwork.JoinOrCreateRoom(userId, roomOptions, null);
	}

	public void JoinRoom()
	{
		PhotonNetwork.JoinRoom("user0");
		photonPlayer = new PhotonPlayer(false, 1, userName);
	}

	//ルームに入室した時に呼び出される
	void OnJoinedRoom()
	{
		Debug.Log("PhotonManager OnJoinedRoom");
		GameObject.Find("StatusText").GetComponent<Text>().text = "OnJoinedRoom";
		GameObject.Find("StartBtn").GetComponent<Button>().interactable = true;
		//ここでキャラクターなどのプレイヤー間で共有するGameObjectを作成すると良い
		players[actID] = PhotonNetwork.Instantiate("Player"+actID,new Vector3(0,0,0), Quaternion.Euler(Vector3.zero), 0);

		test = 2;
	}

	//CustomRoomPropertiesが変更された際に呼ばれます。
	void OnPhotonCustomRoomPropertiesChanged()
	{
	}
}
