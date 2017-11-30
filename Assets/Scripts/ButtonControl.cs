﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickLeft()
	{
		Debug.Log("Left click!");
	}
	public void OnClickRight()
	{
		Debug.Log("Right click!");
	}
	public void OnClickAction()
	{
		Debug.Log("Action click!");
	}
	public void OnClickJump()
	{
		Debug.Log("Jump click!");
	}
}
