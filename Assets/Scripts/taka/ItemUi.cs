using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
	//Player gameobject;
	public GameObject player;

	//UI sprite
	public GameObject Item0sprite, Item1sprite, ActionbtnA, ActionbtnB;
	Sprite Energyimg, Carrotimg, Pickelimg, Sekibanimg, Taimatuimg;


	//Item
	public GameObject Energy, Carrot, Pickel, Sekiban, Taimatu;
	public Sprite nullimg;
	public string Item0st, Item1st, Item2st;
	public bool LadderSwitch, SekibanSwitch;

	//Action image
	public Sprite EnergyACT, CarrotACT, PickelACT, SekibanACT, TaimatuACT, Ladder, LadderUp, LadderDown;

	//Sekibantobira
	public GameObject MoveWall;
	public GameObject ActionBTN;


	private void Start()
	{
		Energyimg = Energy.GetComponent<SpriteRenderer>().sprite;
		Carrotimg = Carrot.GetComponent<SpriteRenderer>().sprite;
		Pickelimg = Pickel.GetComponent<SpriteRenderer>().sprite;
		Taimatuimg = Taimatu.GetComponent<SpriteRenderer>().sprite;
		Sekibanimg = Sekiban.GetComponent<SpriteRenderer>().sprite;
		ActionbtnA.SetActive(false); ActionbtnB.SetActive(false);
		LadderSwitch = false;
		Item0sprite.GetComponent<Image>().sprite = nullimg; Item1sprite.GetComponent<Image>().sprite = nullimg;
	}
	void Update()
	{
		Item0st = player.GetComponent<Player>().Item0;
		Item1st = player.GetComponent<Player>().Item1;
		switch (LadderSwitch)
		{
			case false://梯子が近くにないとき
				if (Item0st == " ")
				{
					ActionbtnA.SetActive(false);
					ActionbtnB.SetActive(false);
				}
				else
				{
					ActionbtnA.SetActive(false);
					ItemSwitcging();
				}
					break;

			case true://梯子が近くにあるとき
				if (Item0st == " ")
				{
					ActionbtnA.SetActive(false);
					ActionbtnB.SetActive(true);
					ActionbtnB.GetComponent<Image>().sprite = Ladder;
				}
				else
				{
					ActionbtnA.SetActive(true);
					ActionbtnA.GetComponent<Image>().sprite = Ladder;
				}
				break;
		}
		if (player.GetComponent<Player>().isClimb == true)
		{
			ActionbtnA.SetActive(true); ActionbtnB.SetActive(true);
			ActionbtnA.GetComponent<Image>().sprite = LadderUp;
			ActionbtnB.GetComponent<Image>().sprite = LadderDown;
		}
		else
		{
			switch (Item0st)    //Item0stに入ってる文字からItemのsprite変更とActionのspriteの変更
			{
				case "Energy":
					Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
					Item0sprite.GetComponent<Image>().sprite = Energyimg; ActionbtnB.GetComponent<Image>().sprite = EnergyACT;
					break;
				case "Carrot":
					Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
					Item0sprite.GetComponent<Image>().sprite = Carrotimg; ActionbtnB.GetComponent<Image>().sprite = CarrotACT;
					break;
				case "Pickel":
					Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
					Item0sprite.GetComponent<Image>().sprite = Pickelimg; ActionbtnB.GetComponent<Image>().sprite = PickelACT;
					break;
				case "Taimatu":
					Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
					Item0sprite.GetComponent<Image>().sprite = Taimatuimg; ActionbtnB.GetComponent<Image>().sprite = TaimatuACT;
					break;
				case "Sekiban":
					Item0sprite.SetActive(true); Item0sprite.GetComponent<Image>().sprite = Sekibanimg;
					if (SekibanSwitch)
					{
						ActionbtnB.SetActive(true);
						ActionbtnB.GetComponent<Image>().sprite = SekibanACT;
					}
					else
					{
						ActionbtnB.SetActive(false);
					}

					break;
			}
			switch (Item1st)//Item1stに入ってる文字からItemのsprite変更
			{
				case "Energy":
					Item1sprite.SetActive(true); Item1sprite.GetComponent<Image>().sprite = Energyimg;
					break;
				case "Carrot":
					Item1sprite.SetActive(true); Item1sprite.GetComponent<Image>().sprite = Carrotimg;
					break;
				case "Pickel":
					Item1sprite.SetActive(true); Item1sprite.GetComponent<Image>().sprite = Pickelimg;
					break;
				case "Taimatu":
					Item1sprite.SetActive(true); Item1sprite.GetComponent<Image>().sprite = Taimatuimg;
					break;
				case "Sekiban":
					Item1sprite.SetActive(true); Item1sprite.GetComponent<Image>().sprite = Sekibanimg;
					break;
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (Item0st == " ")
			{
				Item0sprite.GetComponent<Image>().sprite = nullimg;
				ActionbtnB.SetActive(false);
			}
			if (Item1st == " ")
			{
				Item1sprite.GetComponent<Image>().sprite = nullimg;
			}
		}
	}


	public void UiErase()        //Animationが終了したときItem0 or Item1にものが入っていないことを確認し、個々のSpriteをDestroy
	{
		if (Item0st == " ")
		{
			ActionbtnB.SetActive(false);
			Item0sprite.GetComponent<Image>().sprite = nullimg;
		}
		if (Item1st == " ")
		{
			Item1sprite.GetComponent<Image>().sprite = nullimg;
		}
	}
	public void MoveWallOn()
	{
		MoveWall.GetComponent<Animator>().Play("MoveWallOnEvent");
		Debug.Log("dada");
		MoveWall.SetActive(false);
	}
	public void ItemSwitcging()
	{
		switch (Item0st)    //Item0stに入ってる文字からItemのsprite変更とActionのspriteの変更
		{
			case "Energy":
				Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
				Item0sprite.GetComponent<Image>().sprite = Energyimg; ActionbtnB.GetComponent<Image>().sprite = EnergyACT;
				break;
			case "Carrot":
				Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
				Item0sprite.GetComponent<Image>().sprite = Carrotimg; ActionbtnB.GetComponent<Image>().sprite = CarrotACT;
				break;
			case "Pickel":
				Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
				Item0sprite.GetComponent<Image>().sprite = Pickelimg; ActionbtnB.GetComponent<Image>().sprite = PickelACT;
				break;
			case "Taimatu":
				Item0sprite.SetActive(true); ActionbtnB.SetActive(true);
				Item0sprite.GetComponent<Image>().sprite = Taimatuimg; ActionbtnB.GetComponent<Image>().sprite = TaimatuACT;
				break;
			case "Sekiban":
				Item0sprite.SetActive(true); Item0sprite.GetComponent<Image>().sprite = Sekibanimg;
				if (SekibanSwitch)
				{
					ActionbtnB.SetActive(true);
					ActionbtnB.GetComponent<Image>().sprite = SekibanACT;
				}
				else
				{
					ActionbtnB.SetActive(false);
				}

				break;
		}
	}
}

