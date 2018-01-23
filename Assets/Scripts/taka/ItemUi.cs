using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
	//Player gameobject
	public GameObject player;

	//UI sprite
	public GameObject Item0sprite, Item1sprite, Actionbtn;
	Sprite Energyimg, Carrotimg, Pickelimg, Torchimg;

	//Item
	public GameObject Energy, Carrot, Pickel, Torch;
	public Sprite nullimg;
	string Item0st, Item1st;
	int Item0num, Item1num;

	//Action image
	public Sprite EnergyACT, CarrotACT, PickelACT, TorchACT;


	private void Start()
	{
		//各アイテムのスプライト画像を保存
		Energyimg = Energy.GetComponent<SpriteRenderer>().sprite;
		Carrotimg = Carrot.GetComponent<SpriteRenderer>().sprite;
		Pickelimg = Pickel.GetComponent<SpriteRenderer>().sprite;
		Torchimg = Torch.GetComponent<SpriteRenderer>().sprite;
		Item0num = 0;
	}
	void Update()
	{
		//プレイヤーの所持アイテムをここで読み込む
		Item0st = player.GetComponent<Player>().Item0;
		Item1st = player.GetComponent<Player>().Item1;

		//アイテムボックス０のアイテム
		switch (Item0st)
		{
			case "Energy":
				Item0sprite.GetComponent<Image>().sprite = Energyimg;
				Actionbtn.GetComponent<Image>().sprite = EnergyACT; Item0num = 1;
				break;

			case "Carrot":
				Item0sprite.GetComponent<Image>().sprite = Carrotimg;
				Actionbtn.GetComponent<Image>().sprite = CarrotACT; Item0num = 1;
				break;

			case "Pickel":
				Item0sprite.GetComponent<Image>().sprite = Pickelimg;
				Actionbtn.GetComponent<Image>().sprite = PickelACT; Item0num = 1;
				break;

			case "Torch":
				Item0sprite.GetComponent<Image>().sprite = Torchimg;
				Actionbtn.GetComponent<Image>().sprite = TorchACT; Item0num = 1;
				break;
		}

		//アイテムボックス１のアイテム
		switch (Item1st)
		{
			case "Energy":
				Item1sprite.GetComponent<Image>().sprite = Energyimg; Item1num = 1;
				break;

			case "Carrot":
				Item1sprite.GetComponent<Image>().sprite = Carrotimg; Item1num = 1;
				break;

			case "Pickel":
				Item1sprite.GetComponent<Image>().sprite = Pickelimg; Item1num = 1;
				break;

			case "Torch":
				Item1sprite.GetComponent<Image>().sprite = Torchimg; Item1num = 1;
				break;
		}
		if (Item0st == " ")
		{
			Item0sprite.GetComponent<Image>().sprite = nullimg;

		}
		if (Item1st == " ")
		{
			Item1sprite.GetComponent<Image>().sprite = nullimg;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			Sprite Item2sprite;
			Item2sprite = Item0sprite.GetComponent<Image>().sprite;
			Item0sprite.GetComponent<Image>().sprite = Item1sprite.GetComponent<Image>().sprite;
			Item1sprite.GetComponent<Image>().sprite = Item2sprite;
		}
	}
}
