using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	[SerializeField]
	private GameObject player;	
	[SerializeField]
	private Animator playerAnimator;

	//private SpriteRenderer playerSprite;

	private Vector2 playerPos;
	private Quaternion playerRot;
	private int animaNom;
	private bool specialAction = false;
	private float animationTime;
	private bool isGround = true;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		//playerSprite = GetComponent<SpriteRenderer>();
		playerPos = transform.position;
		playerRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(specialAction == false)
		{
			Move();			
		}

		else if(specialAction == true)
		{
			animationTime = playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
			if(animationTime >= 1.0f)
			{
				specialAction = false;
			}
		}

		Jump();

		if(isGround == false)
		{
			//playerPos.y -= 0.1f;
		}

		transform.position = playerPos;
	}

	//プレイヤー移動
	int Move()
	{
		//int i = 0;

		if (Input.GetKey("left"))
		{
			playerPos += Vector2.left * 0.05f;
			animaNom = -1;
		}
		else if (Input.GetKey("right"))
		{
			playerPos += Vector2.right * 0.05f;
			animaNom = 1;
		}

		else
		{
			animaNom = 0;
		}

		Animation(animaNom);
	
		return 0;
	}

	void Jump()
	{

		float posY = transform.position.y;
		
		if (Input.GetKeyDown("up")&&isGround == true)
		{
			specialAction = true;
			Animation(2);
			posY = transform.position.y + 3.0f;
			//playerPos.y += 3;
		}

		while (playerPos.y <= posY)
		{
			playerPos.y = Mathf.Lerp(transform.position.y, posY, 0.1f);
		}
		
	}

	//プレイヤーアニメーション
	int Animation(int i)
	{
		switch (i)
		{
			//止まっている
			case 0:
				playerAnimator.Play("playerStop");

				break;
            //右移動
			case 1:
				playerAnimator.Play("playerMove");
				playerRot.y = -180;

				break;
            //左移動
			case -1:
				playerAnimator.Play("playerMove");
				if(playerRot.y < 0)
				{
					playerRot.y = 0;
				}
					
				break;

            //ジャンプ
			case 2:
				playerAnimator.Play("playerJump");
				

				break;
			
		};

		transform.rotation = playerRot;
		
		return 0;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Stage")
		{
			isGround = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Stage")
		{
			isGround = false;
		}
	}

}
