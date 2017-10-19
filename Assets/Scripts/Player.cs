using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	[SerializeField]
	private GameObject player;
	private SpriteRenderer playerSprite;
	[SerializeField]
	private Animator playerAnimator;

	private Vector2 playerPos;
	private Quaternion playerRot;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerSprite = GetComponent<SpriteRenderer>();
		playerPos = transform.position;
		playerRot = transform.rotation;
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
			playerPos += Vector2.left * 0.05f;
			i = -1;
		}
		else if (Input.GetKey("right"))
		{
			playerPos += Vector2.right * 0.05f;
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
		switch (i)
		{

			case 0:
				playerAnimator.Play("playerStop");

				break;
			case -1:
				playerAnimator.Play("playerMove");
				playerRot.y = -180;

				break;
			case 1:
				playerAnimator.Play("playerMove");
				if(playerRot.y < 0)
				{
					playerRot.y = 0;
				}
					
				break;
			
		};transform.rotation = playerRot;
		
		return 0;
	}
}
