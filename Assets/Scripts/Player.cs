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
	private bool isGround = false;
	private float posY;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		//playerSprite = GetComponent<SpriteRenderer>();
		playerPos = transform.position;
		playerRot = transform.rotation;
		posY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		animationTime = playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

		if(specialAction == false)
		{
			Move();			
		}

		else if(specialAction == true)
		{		
			if(animationTime >= 1.0f)
			{
				specialAction = false;
			}
		}

		Jump();

		//if(isGround == false)
		//{
		//	playerPos.y -= 0.1f;
		//}

		transform.position = playerPos;
	}

	//プレイヤー移動
	int Move()
	{

		if (Input.GetKey("left"))
		{
			playerPos += Vector2.left * 0.06f;
			animaNom = -1;
		}
		else if (Input.GetKey("right"))
		{
			playerPos += Vector2.right * 0.06f;
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
		
		if (Input.GetKeyDown("up")&&isGround == true)
		{
			specialAction = true;
			animaNom = 2;
			Animation(animaNom);
			posY = playerPos.y + 4.0f;
			
		}
		if (animationTime<=0.5 && animaNom == 2)
		{
			playerPos.y = Mathf.Lerp(playerPos.y, posY, 0.1f);

		}

		if (isGround == false)
		{
			playerPos.y -= 0.1f;
			//if (animationTime > 0.5)
			//{
			//	playerPos.y -= 0.15f;
			//}


			if (Input.GetKey("left"))
			{
				playerPos += Vector2.left * 0.03f;
			}
			else if (Input.GetKey("right"))
			{
				playerPos += Vector2.right * 0.03f;
			}
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


	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			isGround = true; Debug.Log("S");
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			isGround = false;Debug.Log("E");
		}
	}

}
