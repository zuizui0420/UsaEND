using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
	//Player gameobject
	public GameObject player;

	//UI sprite
	public GameObject Item0sprite, Item1sprite, Actionbtn, ActionbtnDown, ActionbtnTop;
	Sprite Energyimg, Carrotimg, Pickelimg, Sekibanimg, Taimatuimg;

	//Item
	public GameObject Energy, Carrot, Pickel, Sekiban, Taimatu;
	public Sprite nullimg;
	public string Item0st, Item1st, Item2st;
	public bool LadderSwitch;

	//Action image
	public Sprite EnergyACT, CarrotACT, PickelACT, SekibanACT, TaimatuACT,LadderACT, SekibaninACT;

	//Sekibantobira
	public GameObject Sekibantobira;


	private void Start()
	{
		Energyimg = Energy.GetComponent<SpriteRenderer>().sprite;
		Carrotimg = Carrot.GetComponent<SpriteRenderer>().sprite;
		Pickelimg = Pickel.GetComponent<SpriteRenderer>().sprite;
		Taimatuimg = Taimatu.GetComponent<SpriteRenderer>().sprite;
		Sekibanimg = Sekiban.GetComponent<SpriteRenderer>().sprite;
		Actionbtn.SetActive(false);
		ActionbtnTop.SetActive(false);
		LadderSwitch = false;
		Item0sprite.GetComponent<Image>().sprite = nullimg;
		Item1sprite.GetComponent<Image>().sprite = nullimg;
	}
	void Update()
	{

		Item0st = player.GetComponent<Player>().Item0;
		Item1st = player.GetComponent<Player>().Item1;
		switch (LadderSwitch)
		{
			case false:
				ActionbtnTop.SetActive(false); ActionbtnDown.SetActive(false);
				break;
			case true:
				ActionbtnTop.SetActive(false); ActionbtnDown.SetActive(false); Actionbtn.SetActive(true);
				Actionbtn.GetComponent<Image>().sprite = LadderACT;
				break;
		}
		if (player.GetComponent<Player>().isClimb == true)
		{
			ActionbtnDown.SetActive(true);
			ActionbtnTop.SetActive(true);
		}
		else
		{
			switch (Item0st)    //Item0stに入ってる文字からItemのsprite変更とActionのspriteの変更
			{
				case "Energy":
					Item0sprite.SetActive(true); Actionbtn.SetActive(true); Item0sprite.GetComponent<Image>().sprite = Energyimg; Actionbtn.GetComponent<Image>().sprite = EnergyACT;
					break;
				case "Carrot":
					Item0sprite.SetActive(true); Actionbtn.SetActive(true); Item0sprite.GetComponent<Image>().sprite = Carrotimg; Actionbtn.GetComponent<Image>().sprite = CarrotACT;
					break;
				case "Pickel":
					Item0sprite.SetActive(true); Actionbtn.SetActive(true); Item0sprite.GetComponent<Image>().sprite = Pickelimg; Actionbtn.GetComponent<Image>().sprite = PickelACT;
					break;
				case "Taimatu":
					Item0sprite.SetActive(true); Actionbtn.SetActive(true); Item0sprite.GetComponent<Image>().sprite = Taimatuimg; Actionbtn.GetComponent<Image>().sprite = TaimatuACT;
					break;
				//case "Sekiban":
				//	if (player.GetComponent<Player>().sekiban == true)
				//	{
				//		Item0sprite.SetActive(true); Item0sprite.GetComponent<Image>().sprite = Sekibanimg; Actionbtn.GetComponent<Image>().sprite = SekibanACT;
				//	}
				//	break;
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
				//case "Sekiban":
				//	Item1sprite.SetActive(true); Item1sprite.GetComponent<Image>().sprite = Sekibanimg;
				//	break;
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (Item0st == " ")
			{
				Item0sprite.GetComponent<Image>().sprite = nullimg;
				Actionbtn.SetActive(false);
			}
			if (Item1st == " ")
			{
				Item1sprite.GetComponent<Image>().sprite = nullimg;
			}
		}
	}
	public void SekibanOnAnimation()
	{
		Sekibantobira.GetComponent<Animator>().Play("SekibanEvent");
	}
}
