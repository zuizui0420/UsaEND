using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingWalk : MonoBehaviour
{
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

    public bool go = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = transform.position;
        playerRot = transform.rotation;
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        animationTime = playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (specialAction == false)
        {
            Move();
        }

        else if (specialAction == true)
        {
            if (animationTime >= 1.0f)
            {
                specialAction = false;
            }
        }

        transform.position = playerPos;
    }

    //プレイヤー移動
    int Move()
    {
        if (go)
        {
            playerPos += Vector2.right * 0.3f;
            animaNom = 1;
        }
        else
        {
            animaNom = 0;
        }

        Animation(animaNom);

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
                if (playerRot.y < 0)
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
