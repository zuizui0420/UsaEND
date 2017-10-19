using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	[SerializeField]
	private GameObject player;
	private SpriteRenderer playerSprite;
	
	[SerializeField]
	private Sprite[] sprites = new Sprite[4];

	private Vector2 playerPos;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerSprite = GetComponent<SpriteRenderer>();
		playerPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	int Move()
	{
		int i = 0;

		if (Input.GetKey("left"))
		{
			playerPos += Vector2.left * 0.1f;
			i = -1;
		}
		else if (Input.GetKey("right"))
		{
			playerPos += Vector2.right * 0.1f;
			i = 1;
		}

		else
		{
			i = 0;
		}

		MoveAnimation(i);

		transform.position = playerPos;
		return 0;
	}

	int MoveAnimation(int i)
	{
		int frameCount;

		switch (i)
		{

			case 0:
				playerSprite.sprite = sprites[0];

				break;
			case -1:
				playerSprite.sprite = sprites[1];
				playerSprite.sprite = sprites[3];
				
				break;
			case 1:
				playerSprite.sprite = sprites[2];
				break;
			
		};

		while(i != 0)
		{

		}
			
		
		return 0;
	}
}
