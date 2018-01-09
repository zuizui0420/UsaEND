using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class GameControl : MonoBehaviour {

	[SerializeField] GameObject[] players = new GameObject[2];

	private bool[] isDead = new bool[4];
	//private int playerNom;

 	public bool gameStart;

	void Awake()
	{
		////シーン間を引き継ぐ
		DontDestroyOnLoad(this);

		for (int i=0; i < 2; i++)
		{
			Instantiate(players[i]);
			players[i] = GameObject.FindWithTag("Player"+i);
		}

		
	}


	// Use this for initialization
	void Start() {
		
	}

	// Update is called once per frame
	void Update() {

	}

	public bool DeadFlag
	{
		set
		{
			isDead[0] = true;
		}
		get
		{
			return isDead[0];
		}
	}
	
}
