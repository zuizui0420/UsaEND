using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;


public class GameControl : MonoBehaviour {


	private bool[] isDead = new bool[4];
	//private int playerNom;

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
