﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBtnControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickStart()
	{
		GameObject.Find("MultiGameController").GetComponent<MultiGameControl>().gameStart = true;
	}
}