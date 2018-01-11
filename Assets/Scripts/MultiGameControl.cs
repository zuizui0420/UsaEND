using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGameControl : Photon.MonoBehaviour
{
	[SerializeField]
	GameObject[] players = new GameObject[2];

	public int actID = -1;
	//public int playerNom = -1;

	private bool[] isDead = new bool[4];
	//private int playerNom;

	public bool gameStart;

	void Awake()
	{
		//シーン間を引き継ぐ
		DontDestroyOnLoad(this);

		for (int i = 0; i < 2; i++)
		{
			//Instantiate(players[i]);
			//players[i] = GameObject.FindWithTag("Player" + i);
		}


	}

	// Use this for initialization
	void Start () {
		gameStart = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if(actID != playerNom)
		//{
		//	//CreateCharacter();
		//}
	
	}

	//public bool DeadFlag
	//{
	//	set
	//	{
	//		isDead[0] = true;
	//	}
	//	get
	//	{
	//		return isDead[0];
	//	}
	//}

	//void CreateCharacter()
	//{
	//	PhotonNetwork.Instantiate("Player" + actID, new Vector3(0, 0, 0), Quaternion.Euler(Vector3.zero), 0);
	//	playerNom = actID;
	//}


	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			//データの送信
			stream.SendNext(gameStart);
		}
		else
		{
			//データの受信
			this.gameStart = (bool)stream.ReceiveNext();
		}
	}
}
