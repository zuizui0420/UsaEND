﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonControl : MonoBehaviour {

	GameObject player;
	GameObject resultUI;
	GameObject reStartBtn;


	public static bool isRight { get; private set; }
	public static bool isLeft { get; private set; }
	public static bool isAction { get; private set; }
	public static bool isActionA { get; private set; }
	public static bool isActionB { get; private set; }
	public static bool isJump { get; private set; }
	public static bool isSwitchItem {  get; set; }


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player0");
		resultUI = GameObject.Find("GameResultUI");
		reStartBtn = GameObject.Find("ReStartBtn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickLeft()
	{
		//Debug.Log("Left click!");
		isLeft = true;

	}

	public void UpClickLeft()
	{
		isLeft = false;
	}
	public void OnClickRight()
	{
		//Debug.Log("Right click!");
		isRight = true;
	}
	public void UpClickRight()
	{
		isRight = false;
	}
	public void OnClickAction()
	{
		//Debug.Log("Action click!");
		isAction= true;
	}
	public void UpClickAction()
	{
		isAction = false;
	}
	public void OnClickActionA()
	{
		//Debug.Log("Action click!");
		isActionA = true;
	}
	public void UpClickActionA()
	{
		isActionA = false;
	}
	public void OnClickActionB()
	{
		//Debug.Log("Action click!");
		isActionB = true;
	}
	public void UpClickActionB()
	{
		isActionB = false;
	}

	public void OnClickJump()
	{
		//Debug.Log("Jump click!");
		isJump = true;
	}
	public void UpClickJump()
	{
		isJump = false;
	}

	public void OnClickItemSwitch()
	{
		isSwitchItem = true;
	}
	
	public void OnClickToMenuBtn()
	{
		SceneManager.LoadScene("MenuScene");
	}
	public void OnClickNextBtn()
	{
		SceneManager.LoadScene("Stage01");
	}

	public void Restart()
	{
		reStartBtn.GetComponent<Button>().interactable = false;
		player.GetComponent<Player>().isRestart = true;
		StartCoroutine("RestartInter");	
	}

	IEnumerator RestartInter()
	{
		yield return new WaitForSeconds(0.5f);
		resultUI.GetComponent<StageResultUI>().isRestsrt = true;
		player.GetComponent<Player>().isRestart = false;
		reStartBtn.GetComponent<Button>().interactable = true;
	}
}
