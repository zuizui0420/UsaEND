using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Photon.MonoBehaviour
{
	[SerializeField]
	private GameObject playerPre; //ソロ用のプレイヤー

	[SerializeField]
	private GameObject player;	
	[SerializeField]
	private Animator playerAnimator;


	private GameObject[] startPos = new GameObject[2];
	private GameObject ItemUI;


	public int actID;//ルーム内のプレイヤーID
	public int playerID;//PlayerスクリプトでのプレイヤーID

	private PhotonView photonView;
	private PhotonTransformView photonTransformView;


	public enum PLAYER_STATE
	{
		ALIVE,
		DEAD,
		MENU,
		GOAL
		
	};

	public PLAYER_STATE playerState;

	public int InputDet;//入力検知

	private Vector2 playerPos;
	private Quaternion playerRot;
	public int animaNom;
	public bool specialAction = false;
	public float animationTime;
	public bool isGround = false;
	public float jumpTopPos;//ジャンプの最高地点
	private int jumpCount = 0;
	public float speed = 0.06f;
	public float noGroundPos;//離陸地点
	public float onGroundPos;//着地地点
	private Rigidbody2D rig;
	public bool isDying;
	public bool isDead;
	public bool isClimb;
	public bool isJump;
	public int DeadCount;
	int i = 0;
	public bool isRestart = false;

	public bool isGoal = false;

	private Vector2 ladderPos;

	//移動制御 true or false
	int StopMove;
	int StopInput;

	//Item Ui
	public string Item0, Item1;
	GameObject breakwall;
	bool Break;

	//デバック用
	private float nextTime;

	void Awake()
	{
		try {
			actID = GameObject.Find("PhotonManager").GetComponent<PhotonManager>().actID;
		}
		catch {
			actID = 0;
		}
		
		//actID = int.Parse(this.gameObject.tag.Substring(6));
		//プレイヤーのタグの末尾をintにしてプレイヤーIDとして設定
		playerID = int.Parse(player.tag.Substring(6));
	}


	// Use this for initialization
	void Start () {
		//player = GameObject.FindWithTag("Player"+playerID);
		player = GameObject.FindWithTag("Player" + actID);
		//playerID = actID;

		photonTransformView = GetComponent<PhotonTransformView>();
		photonView = PhotonView.Get(this);

		//SceneManager.sceneLoaded += OnSceneLoaded;//デリゲートの登録

		DeadCount = 0;

		playerPos = transform.position;
		playerRot = transform.rotation;
		playerRot.y = -180;
		//posY = transform.position.y;//これ必要？
		rig = GetComponent<Rigidbody2D>();

		StopMove = 0;
		Item0 = " ";
		Item1 = " ";

		isDead = false;
		isClimb = false;
		isJump = false;

		switch (playerState)
		{
			case PLAYER_STATE.ALIVE:
				ItemUI = GameObject.Find("ItemUI");
				break;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

		//Debug.Log(noGroundPos - onGroundPos);

		//マルチでのルーム内のキャラの引き継ぎ
		//if (actID != -1 && playerState != PLAYER_STATE.MENU)
		//{
		//	//シーン間を引き継ぐ
		//	//DontDestroyOnLoad(this);
		//}

		//if (playerID != actID) return;

		//マルチで使用
		//if (photonView.isMine)
		//{
		//	//現在の移動速度
		//	Vector2 velocity = rig.velocity;
		//	//移動速度を指定
		//	photonTransformView.SetSynchronizedValues(velocity, 0);
		//}

		animationTime = playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

		playerPos = transform.position;

		Animation(animaNom);//アニメーション再生

		switch (playerState)
		{
			case PLAYER_STATE.ALIVE:


				isDead = false;
				
				GameObject.Find("GameResultUI").GetComponent<StageResultUI>().HideGameOverUI();

				if (!isDying)
				{
					if (specialAction == true)
					{
						if (animationTime >= 1.0f)
						{
							specialAction = false;
							isJump = false;
						}
					}

					if (isGround == true)
					{
						speed = 0.06f;
						if (isJump == false) Move();

					}

					//空中の処理
					else if (isGround == false)
					{

						playerPos.y -= 0.1f;
						if (isJump == false && specialAction == false)
						{
							animaNom = 4;
							speed = 0.02f;
						}

						if (Input.GetKey("left") || ButtonControl.isLeft)
						{
							playerPos += Vector2.left * speed;
							playerRot.y = 0;
						}
						else if (Input.GetKey("right") || ButtonControl.isRight)
						{
							playerPos += Vector2.right * speed;
							playerRot.y = -180;
						}
					}

					//ジャンプ中の処理
					if (animationTime <= 0.5 && animaNom == 2)
					{
						playerPos.y = Mathf.Lerp(playerPos.y, jumpTopPos, 0.1f);
					}


					if (isClimb == true)
					{
						ClimbLadder();
					}

					if (Input.GetKey(KeyCode.Alpha1) || ButtonControl.isAction)
					{
						if (StopInput == 0 && isGround == true)
						{
							switch (Item0)
							{
								case "Energy":
									GetEnergyUse(); Item0 = " ";
									break;
								case "Carrot":
									GetCarrotUse(); Item0 = " ";
									break;
								case "Pickel":
									GetPickelUse(); Item0 = " ";
									break;
								case "Torch":
									GetTorchUse(); Item0 = " ";
									break;
							}
						}
					}


					if (Input.GetKeyDown(KeyCode.E)||ButtonControl.isSwitchItem)
					{
						string Item2;
						Item2 = Item0;
						Item0 = Item1;
						Item1 = Item2;
						ButtonControl.isSwitchItem = false;
					}

					//高さ4以上で死ぬ
					if (noGroundPos - onGroundPos >= 4)
					{
						Dying();

						//isDead = true;
					}

					//プレイヤーがエナジードリンクを使ったら
					if (animaNom == 7)
					{
						FlyAway();
					}


				}

				//プレイヤーがエナジードリンクを使ったら
				//if (animaNom == 7)
				//{
				//	FlyAway();
				//}

				//他のスクリプトから読み出したときはここでDying()を実行(Dyingメソッドの処理が重なるため)
				else if (isDying)
				{
					Dying();
					return;

				}

				

				//ゴール後
				if (isGoal == true)
				{
					SceneManager.LoadScene("GoalScene");
				}

				break;

			case PLAYER_STATE.DEAD:

				animaNom = 6;
				isDead = true;

				//ゲームオーバーUIを表示
				GameObject.Find("GameResultUI").GetComponent<StageResultUI>().AppearUI(0);

				//リスタート
				if (isRestart)
				{
					StartCoroutine("Restart");
				}

				break;

			case PLAYER_STATE.MENU:

				speed = 0;
				if (specialAction == true)
				{
					if (animationTime >= 1.0f)
					{
						specialAction = false;
						isJump = false;
					}
				}

				if (isGround == true)
				{
					if (isJump == false) Move();

				}

				//空中の処理
				else if (isGround == false)
				{

					playerPos.y -= 0.1f;
					if (isJump == false && specialAction == false)
					{
						animaNom = 4;
					}

					if (Input.GetKey("left") || ButtonControl.isLeft)
					{
						playerPos += Vector2.left * speed;
						playerRot.y = 0;
					}
					else if (Input.GetKey("right") || ButtonControl.isRight)
					{
						playerPos += Vector2.right * speed;
						playerRot.y = -180;
					}
				}

				//ジャンプ中の処理
				if (animationTime <= 0.5 && animaNom == 2)
				{
					playerPos.y = Mathf.Lerp(playerPos.y, jumpTopPos, 0.1f);
				}
				break;

			case PLAYER_STATE.GOAL:
				speed = 0.06f;
				if (specialAction == true)
				{
					if (animationTime >= 1.0f)
					{
						specialAction = false;
						isJump = false;
					}
				}

				if (isGround == true)
				{
					if (isJump == false) Move();

				}

				//空中の処理
				else if (isGround == false)
				{

					playerPos.y -= 0.1f;
					if (isJump == false && specialAction == false)
					{
						animaNom = 4;
					}

					if (Input.GetKey("left") || ButtonControl.isLeft)
					{
						playerPos += Vector2.left * speed;
						playerRot.y = 0;
					}
					else if (Input.GetKey("right") || ButtonControl.isRight)
					{
						playerPos += Vector2.right * speed;
						playerRot.y = -180;
					}
				}

				//ジャンプ中の処理
				if (animationTime <= 0.5 && animaNom == 2)
				{
					playerPos.y = Mathf.Lerp(playerPos.y, jumpTopPos, 0.1f);
				}
				break;

		}
	}


	private void FixedUpdate()
	{
		rig.MovePosition(playerPos);
	}
	
	//シーン読み込みデリゲート
	//void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	//{
	//	if(SceneManager.GetActiveScene().name== "Stage01"|| SceneManager.GetActiveScene().name == "GoalScene")//現在のシーンがステージシーンであるか？
	//	{
	//		//player = GameObject.FindWithTag("Player" + actID);
	//		//プレイヤーのスタートPos
	//		player.GetComponent<Transform>().transform.position = GameObject.Find("StartPos"+playerID).GetComponent<Transform>().transform.position;

	//		//プレイヤーのスタートPosを初期値に設定(シーンロード時にスタートPosにズレが生じるため)
	//		playerPos = transform.position;
	//		playerRot = transform.rotation;
	//		playerRot.y = -180;
			
	//	}
		
	//	Debug.Log(scene.name + " scene loaded");
	//}



	//プレイヤー移動
	int Move()
	{
		if (specialAction == false && StopMove == 0)
		{
			if (isClimb == false)
			{
				//移動キー
				if (Input.GetKey("left") || ButtonControl.isLeft)
				{
					playerPos += Vector2.left * speed;
					animaNom = -1;
				}

				else if (Input.GetKey("right") || ButtonControl.isRight)
				{
					playerPos += Vector2.right * speed;
					animaNom = 1;
				}

				else
				{
					animaNom = 0;
				}
			}
			//ジャンプキー
			if (Input.GetKeyDown(KeyCode.S) || ButtonControl.isJump)
			{		
				isJump = true;
				speed = 0.04f;
				specialAction = true;
				animaNom = 2;
				Animation(animaNom);
				jumpTopPos = playerPos.y + 3.0f;
				noGroundPos = jumpTopPos;
			}

		}
	
		return 0;
	}

	void ClimbLadder()
	{
		isGround = true;//梯子のあたり判定を呼び出した時isGround=trueが読み込まれていない事があるのでここでも呼び出しておく

		speed = 0.06f;
		specialAction = true; 
		animaNom = 3;
	

		playerPos.x = Mathf.Lerp(playerPos.x, ladderPos.x, 0.2f);


		if (Input.GetKey("up") )
		{
			playerAnimator.speed = 1;
			playerPos += Vector2.up * speed;
			InputDet = 3;
			onGroundPos = player.gameObject.transform.position.y;
			noGroundPos = player.gameObject.transform.position.y;
		}
		else if (Input.GetKey("down"))
		{
			playerAnimator.speed = 1;
			playerPos += Vector2.down * speed;
			InputDet = 4;
			onGroundPos = player.gameObject.transform.position.y;
			noGroundPos = player.gameObject.transform.position.y;
		}		
		else
		{
			playerAnimator.speed = 0;

		}

		//ジャンプキー
		if (Input.GetKeyDown(KeyCode.S) || ButtonControl.isJump)
		{
			playerAnimator.speed = 1;//アニメーションが止まるのでここで強制的にアニメーションを動かす
			InputDet = 4;
			isJump = true;
			specialAction = true;
			animaNom = 2;
			Animation(animaNom);
			jumpTopPos = playerPos.y + 3.0f;
			noGroundPos = jumpTopPos;
			isClimb = false;
			isGround = false;

		}
	}

	public void Dying()
	{
		if (isDead == false)
		{
			animaNom = 5;
			specialAction = true;
			isDead = true;
			i++;
		}
	}

	void Dead()
	{
		isDying = false;

		playerState = PLAYER_STATE.DEAD;
		DeadCount++;

	}

	void FlyAway()
	{
		player.GetComponent<BoxCollider2D>().isTrigger = true;
		isGround = false;
		playerPos.y += 0.05f;
	}


	IEnumerator Restart()
	{
		playerPos = GameObject.Find("StartPos" + 0).GetComponent<Transform>().transform.position;
		player.GetComponent<BoxCollider2D>().isTrigger = false;
		if (player.transform.position == GameObject.Find("StartPos" + 0).GetComponent<Transform>().transform.position)
		{
			
			animaNom = 0;
			playerState = PLAYER_STATE.ALIVE;

			isDying = false;
			isDead = false;

		}

		//animaNom = 0;
		
		yield break;
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
           //死亡
			case 5:
				playerAnimator.Play("playerDying");

				break;

         　//死体
			case 6:
				playerAnimator.Play("playerDead");

				break;

			//エナドリ
			case 7:
				playerAnimator.Play("playerFlyaway");

				break;

			//人参
			case 8:
				playerAnimator.Play("playerCarrot");

				break;

			//ピッケル
			case 9:
				playerAnimator.Play("playerPickel");

				break;
		};

		transform.rotation = playerRot;
		
		return 0;
	}

	public void GetEnergyUse()      //エナドリanimation
	{
		specialAction = true;
		StopMove = 1;
		StopInput = 1;
		animaNom = 7;
		//GetComponent<BoxCollider2D>().enabled = false;
	}
	public void GetCarrotUse()      //人参animation
	{
		StopMove = 1;
		StopInput = 1;
		animaNom = 8;
	}
	public void GetPickelUse()
	{
		StopMove = 1;
		StopInput = 1;
		animaNom = 9;
		if(breakwall != null)			//breakwallに何も入っていない場合呼ばれないように
		{
			breakwall.GetComponent<Animator>().Play("BreakWall");		//breakwallのanimatorからBreakを呼ぶ
		}
		
	}
	public void GetTorchUse()
	{
		StopMove = 1;
		StopInput = 1;
		animaNom = 10;
	}

	public void stpMove()  //移動制御false>true
	{
		StopMove = 0;
		StopInput = 0;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Stage")
		{
			isGround = true;
			if (InputDet == 4) isClimb = false;

			onGroundPos = player.gameObject.transform.position.y;

		}

		if(other.gameObject.tag == "Goal")
		{
			isGoal = true;
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
			ItemUI.GetComponent<ItemUi>().LadderSwitch = true;
			if (Input.GetKeyDown(KeyCode.A)||ButtonControl.isAction)
			{
				isClimb = true;
				ladderPos = collision.gameObject.transform.position;
			}

		}

		if (collision.gameObject.tag == "BreakWall")	//breakwallにオブジェクトデータを保存
		{
			breakwall = collision.gameObject;
			Break = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stage")
		{
			isGround = false;
			if (isJump == false)
			{
				noGroundPos = player.transform.position.y;
			}
		}

		else if (collision.gameObject.tag == "Ladder")
		{
			ItemUI.GetComponent<ItemUi>().LadderSwitch = false;
			isClimb = false;
			isGround = false;
			//noGroundPos = player.transform.position.y;//ジャンプすることで梯子から脱するのでここはいらないはず

		}

		if (collision.gameObject.tag == "MainCamera")
		{
			animaNom = 6;
			stpMove();

		}
		if (collision.gameObject.tag == "BreakWall")	//breakwallのオブジェクトデータをnulへ
		{

			breakwall = null;
			Break = false;
		}
	}

	public void stpMoveDestroy()			//tag "BreakWall"に触れている間ピッケルを使った場合に呼ばれる
	{
		stpMove();
		Destroy(breakwall);
	}
}
