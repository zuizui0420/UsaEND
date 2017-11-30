using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[SerializeField]
	private GameObject player;	
	[SerializeField]
	private Animator playerAnimator;

	private Vector2 playerPos;
	private Quaternion playerRot;
	private int animaNom;
	private bool specialAction = false;
	private float animationTime;
	private bool isGround = false;
	private float posY;
	private int jumpCount = 0;
	private float speed = 0.06f;
	private Rigidbody2D rig;
	private bool isDead = false;

	//デバック用
	float nextTime = Time.time;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerPos = transform.position;
		playerRot = transform.rotation;
		playerRot.y = -180;
		posY = transform.position.y;

		rig = GetComponent<Rigidbody2D>();

		//デバック用
		float nextTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		animationTime = playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

		playerPos = transform.position;

		if (specialAction == false)
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

		/*if(isDead == true)*/ Dead();
		
	}

	private void FixedUpdate()
	{
		rig.MovePosition(playerPos);
	}

	//プレイヤー移動
	int Move()
	{

		if (Input.GetKey("left"))
		{
			playerPos += Vector2.left * speed;
			animaNom = -1;
		}
		else if (Input.GetKey("right"))
		{
			playerPos += Vector2.right * speed;
			animaNom = 1;
		}

		else
		{
			animaNom = 0;
		}

		Animation(animaNom);
	
		return 0;
	}

	int Jump()
	{
		if (Input.GetKeyDown("up") && isGround == true)
		{
			specialAction = true;
			animaNom = 2;
			Animation(animaNom);
			posY = playerPos.y + 3.0f;

		}
		if (animationTime <= 0.5 && animaNom == 2)
		{
			playerPos.y = Mathf.Lerp(playerPos.y, posY, 0.1f);

		}


		if (isGround == false)
		{
			playerPos.y -= 0.1f;
		
			if (Input.GetKey("left"))
			{
				playerPos += Vector2.left * speed;
			}
			else if (Input.GetKey("right"))
			{
				playerPos += Vector2.right * speed;
			}
		}

		return 0;
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

	void Dead()
	{
		float interval = 0.1f;   // 点滅周期

		SpriteRenderer renderer = GetComponent<SpriteRenderer>();

		if (Time.time > nextTime)
		{
			renderer.enabled = !renderer.enabled;

			nextTime += interval;
		}

	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			isGround = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			isGround = false;
		}
	}

}
