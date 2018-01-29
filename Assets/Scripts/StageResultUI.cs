using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageResultUI : MonoBehaviour
{

	public Sprite[] sprites = new Sprite[2];
	private bool isAppare;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	//引数でゲームオーバーかクリアかを判断
	public void AppearUI(int i)
	{
		switch (i)
		{
			//ゲームオーバー時
			case 0:
				GetComponent<Image>().sprite = sprites[0];
				break;

			case 1:
				GetComponent<Image>().sprite = sprites[1];
				break;
		}


		if (isAppare == false)
		{
			GetComponent<Image>().enabled = true;
		} 
	}
}
