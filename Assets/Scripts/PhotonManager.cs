using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//ロビー接続
	void ConnectPhoton()
	{
		PhotonNetwork.ConnectUsingSettings("v1.0");
	}

	//ロビーに入った時に呼び出される
	void OnJoinedLobby()
	{
		Debug.Log("PhotonManager OnJoinedLobby");
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
		string userName = "ユーザ1";
		string userId = "user1";
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

	//ルームに入室した時に呼び出される
	void OnJoinedRoom()
	{
		Debug.Log("PhotonManager OnJoinedRoom");
	}
}
