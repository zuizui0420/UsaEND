using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

 	public static bool isRight { get; private set; }
	public static bool isLeft { get; private set; }
	public static bool isAction { get; private set; }
	public static bool isJump { get; private set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickLeft()
	{
		Debug.Log("Left click!");
		isLeft = true;

	}

	public void UpClickLeft()
	{
		isLeft = false;
	}
	public void OnClickRight()
	{
		Debug.Log("Right click!");
		isRight = true;
	}
	public void UpClickRight()
	{
		isRight = false;
	}
	public void OnClickAction()
	{
		Debug.Log("Action click!");
		isAction= true;
	}
	public void UpClickAction()
	{
		isAction = false;
	}
	public void OnClickJump()
	{
		Debug.Log("Jump click!");
		isJump = true;
	}
	public void UpClickJump()
	{
		isJump = false;
	}
}
