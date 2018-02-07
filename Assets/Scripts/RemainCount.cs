using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainCount : MonoBehaviour {

	GameObject player;

	int cursor;

	int Dead;

	int zero = 0;

	int digit1;
	int digit10;
	int digit100;

	/// <summary>
	/// 残機
	/// </summary>
	public int DeadCount = 0;

	/// <summary>
	/// 桁数の合計
	/// </summary>
	int DigitNum;

	/// <summary>
	/// 数字スプライト配列
	/// </summary>
	public Sprite[] numbers = new Sprite[11];

	/// <summary>
	/// 残機数表示部分配列
	public GameObject[] remainRend = new GameObject[4];

	/// <summary>
	/// 桁数
	/// </summary>
	/// <param name="deadcount"></param>
	/// <returns></returns>
	public int Digit(int deadcount)
	{
		int digit = 1;
		for (int i = deadcount; i >= 10; i /= 10)
		{
			digit++;
		}
		return digit;
	}

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindWithTag("Player0");
	}

	// Update is called once per frame
	void Update()
	{

		DigitNum = Digit(DeadCount);
		DeadCount = player.GetComponent<Player>().DeadCount;

		switch (DigitNum)
		{
			case 0:

				break;
			case 1:
				if (DeadCount != 0)
				{
					remainRend[2].GetComponent<Image>().enabled = false;

					remainRend[1].GetComponent<Image>().enabled = true;
					remainRend[1].GetComponent<Image>().sprite = numbers[10];
					digit1 = DeadCount;

					remainRend[0].GetComponent<Image>().sprite = numbers[digit1];
				}

				else if (DeadCount == 0)
				{
					remainRend[1].GetComponent<Image>().enabled = false;
					remainRend[2].GetComponent<Image>().enabled = false;
					remainRend[0].GetComponent<Image>().sprite = numbers[0];
				}
				break;
			case 2:
				remainRend[3].GetComponent<Image>().enabled = false;

				remainRend[2].GetComponent<Image>().enabled = true;
				remainRend[2].GetComponent<Image>().sprite = numbers[10];
				digit10 = DeadCount / 10;
				digit1 = DeadCount % 10;

				remainRend[0].GetComponent<Image>().sprite = numbers[digit1];
				remainRend[1].GetComponent<Image>().sprite = numbers[digit10];

				break;
			case 3:
				remainRend[3].GetComponent<Image>().enabled = true;
				remainRend[3].GetComponent<Image>().sprite = numbers[10];
				digit100 = DeadCount / 100;
				int w = DeadCount % 100;
				digit10 = w / 10;
				digit1 = w % 10;

				remainRend[0].GetComponent<Image>().sprite = numbers[digit1];
				remainRend[1].GetComponent<Image>().sprite = numbers[digit10];
				remainRend[2].GetComponent<Image>().sprite = numbers[digit100];

				break;

			case 4:
				remainRend[0].GetComponent<Image>().sprite = numbers[9];
				remainRend[1].GetComponent<Image>().sprite = numbers[9];
				remainRend[2].GetComponent<Image>().sprite = numbers[9];
				remainRend[3].GetComponent<Image>().sprite = numbers[10];
				break;

		}

	}
}
