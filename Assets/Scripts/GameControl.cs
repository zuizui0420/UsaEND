using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class GameControl : MonoBehaviour {

	string filePath;
	//[SerializeField] GameObject[] players = new GameObject[2];

	GameObject player;
	private bool isDead;
	//private int playerNom;
	int playerAnimaNom;
	float playerAnimaTime;
    GameData gameData = new GameData();
	//public bool gameStart;

	string json;

	void Awake()
	{

		//ファイルパスを作る
		filePath = Application.persistentDataPath;


		////シーン間を引き継ぐ
		//DontDestroyOnLoad(this);

		//for (int i=0; i < 2; i++)
		//{
		//	Instantiate(players[i]);
		//	players[i] = GameObject.FindWithTag("Player"+i);
		//}


	}


	// Use this for initialization
	void Start() {

		int i = 0;
		GameData.Instance.GameStart++;
		
		GameData.Instance.Save();
		
		//player = GameObject.FindWithTag("Player"+0);

		////gameData.GameStart = 1;
		//gameData.DeadCount = 3;

		//JsonUtility.FromJson<GameData>(json);
		//Debug.Log(gameData.GameStart);

		//json = JsonUtility.ToJson(gameData);
		//Debug.Log(json);

	}

	// Update is called once per frame
	void Update()
	{       //playerAnimaNom = player.GetComponent<Player>().animaNom;
			//playerAnimaTime = player.GetComponent<Player>().animationTime;

		//if (playerAnimaNom >= 6 && playerAnimaTime>=100.0f)
		//{
		//	StartCoroutine("Restart");
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

	//IEnumerator Restart()
	//{
	//	player.GetComponent<Player>().isDead = false;	
	//	player.GetComponent<Transform>().transform.position = GameObject.Find("StartPos" + 0).GetComponent<Transform>().transform.position;
	//	player.GetComponent<Player>().animaNom = 0;
	//	yield break;
	//}

}
