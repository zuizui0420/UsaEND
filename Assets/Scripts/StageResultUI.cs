using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageResultUI : MonoBehaviour
{

	public Sprite[] sprites = new Sprite[2];
	public GameObject backFilter;
	public GameObject resultBtn;
	private bool isAppare;
	public bool isRestsrt;

	bool isDisplay;//すでに表示しているかどうか

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
				if (isDisplay == false)
				{
					StartCoroutine("AppearGameOverUI");
				}
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

	IEnumerator AppearGameOverUI()
	{
		backFilter.active = true;
		yield return new WaitForSeconds(1.0f);
		resultBtn.active = true;
		isDisplay = true;
	}

	public void HideGameOverUI()
	{
		backFilter.active = false;
		resultBtn.active = false;
		isDisplay = false;

		GetComponent<Image>().enabled = false;
	}
}

