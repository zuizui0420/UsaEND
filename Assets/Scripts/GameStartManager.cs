using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStartManager : Photon.MonoBehaviour{

	public bool gameStart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//シーン間を引き継ぐ
		//DontDestroyOnLoad(this);
		if (gameStart == true)
		{
			SceneManager.LoadScene("StageMatsubara");
		}
	}

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
