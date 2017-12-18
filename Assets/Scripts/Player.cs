using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[SerializeField]
	private GameObject player;	
	[SerializeField]
	private Animator playerAnimator;

	public enum PLAYER_STATE
	{
		NOMAL,
		JAMP,
		CLIMB_LADDER,
		
	};

	public PLAYER_STATE playerState;

	public int InputDet;//入力検知

	private Vector2 playerPos;
	private Quaternion playerRot;
	public int animaNom;
	private bool specialAction = false;
	private float animationTime;
	public bool isGround = false;
	private float posY;
	private int jumpCount = 0;
	public float speed = 0.06f;
	private Rigidbody2D rig;
	public bool isDead;
	public bool isClimb;
	public bool isJump;

	private Vector2 ladderPos;
	//デバック用
	private float nextTime;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerPos = transform.position;
		playerRot = transform.rotation;
		playerRot.y = -180;
		posY = transform.position.y;
		rig = GetComponent<Rigidbody2D>();

		isDead = false;
		isClimb = false;
		isJump = false;

		//デバック用
		nextTime = Time.time;

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (isDead == true)
		{
			Dead();
			return;
		}

		animationTime = playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

		playerPos = transform.position;

	
		if(specialAction == true)
		{		
			if(animationTime >= 1.0f)
			{
				specialAction = false;
				isJump = false;
			}
		}

		if (isGround == true)
		{
			speed = 0.06f;
			if(isJump==false)Move();
			
		}

		//空中の処理
		else if (isGround == false)
		{
			
			playerPos.y -= 0.1f;
			if (isJump == false)
			{
				animaNom = 4;
				speed = 0.02f;
				Debug.Log(4);
			}
			
			if (Input.GetKey("left"))
			{
				playerPos += Vector2.left * speed;
				playerRot.y = 0;
			}
			else if (Input.GetKey("right"))
			{
				playerPos += Vector2.right * speed;
				playerRot.y = -180;
			}
		}

		//ジャンプ中の処理
		if (animationTime <= 0.5 && animaNom == 2)
		{
			playerPos.y = Mathf.Lerp(playerPos.y, posY, 0.1f);

		}

		if (isClimb == true) ClimbLadder();

		Animation(animaNom);


		switch (playerState)
		{
			case PLAYER_STATE.NOMAL:
				break;
				}
		
	}

	private void FixedUpdate()
	{
		rig.MovePosition(playerPos);
	}

	//プレイヤー移動
	int Move()
	{
		if (specialAction == false)
		{
			//		speed = 0.06f;

			//移動キー
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
			//ジャンプキー
			if (Input.GetKeyDown(KeyCode.S))
			{
				isJump = true;
				speed = 0.04f;
				specialAction = true;
				animaNom = 2;
				Animation(animaNom);
				posY = playerPos.y + 3.0f;
				Debug.Log("j");
			}

		}
		//Animation(animaNom);
	
		return 0;
	}

	void ClimbLadder()
	{
		isGround = true;//梯子のあたり判定を呼び出した時isGround=trueが読み込まれていない事があるのでここでも呼び出しておく

		speed = 0.06f;
		specialAction = true; 
		animaNom = 3;
		//Animation(animaNom);

		playerPos.x = Mathf.Lerp(playerPos.x, ladderPos.x, 0.2f);


		if (Input.GetKey("up"))
		{
			playerAnimator.speed = 1;
			playerPos += Vector2.up * speed;
			InputDet = 3;
		}
		else if (Input.GetKey("down"))
		{
			playerAnimator.speed = 1;
			playerPos += Vector2.down * speed;
			InputDet = 4;
		}		
		else
		{
			playerAnimator.speed = 0;

		}

		if (Input.GetKeyDown(KeyCode.S))
		{

			isJump = true;
			specialAction = true;
			animaNom = 2;
			Animation(animaNom);
			posY = playerPos.y + 3.0f;
			isClimb = false;
			isGround = false;

		}
	}


	void Dead()
	{
		animaNom = 4;

		float interval = 0.2f;   // 点滅周期

		SpriteRenderer renderer = GetComponent<SpriteRenderer>();

		if (Time.time >= nextTime)
		{
			renderer.enabled = !renderer.enabled;

			nextTime += interval;
		}

		Animation(animaNom);


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

            //梯子
			case 3:
				playerAnimator.Play("playerClimb");
				break;

           //落ちる 
			case 4:
				playerAnimator.Play("playerFall");

				break;
			
		};

		transform.rotation = playerRot;
		
		return 0;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Stage")
		{
			isGround = true;
			if (InputDet == 4) isClimb = false;
		
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			if(isJump==false)isGround = true;
			
		}

		if(collision.gameObject.tag == "Ladder")
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				isClimb = true;
				ladderPos = collision.gameObject.transform.position;
			}

		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			isGround = false;
		}

		else if (collision.gameObject.tag == "Ladder")
		{
			isClimb = false;
			isGround = false;

		}
	}


}
