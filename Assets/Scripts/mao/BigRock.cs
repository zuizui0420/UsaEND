using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRock : MonoBehaviour {


    /// <summary>
    /// 壁用で反射させる
    /// </summary>
    public bool WallHitReflectionGimmick;

    /// <summary>
    /// 床に当たったら壊さない
    /// </summary>
    public bool StageHitNoBreakDown;

    public bool kotei;

    /// <summary>
    /// 左から動く
    /// </summary>
    public bool FromtheLeft;


    /// <summary>
    /// 壁に当たっているか？
    /// </summary>
    bool WalltagColHit = false;

    /// <summary>
    /// 床に当たっているか？
    /// </summary>
    bool StagetagColHit = false;


    public float speed;

	[SerializeField]
    GameObject TrapArea;

    /// <summary>
    /// 罠発動フラグ
    /// </summary>
    bool trapFlagAction;


    // Use this for initialization
    void Start ()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

       
        //TrapArea = GameObject.Find("TrapArea");

        if (kotei)
        {
            rigidbody.simulated = false;
        }
        
    }
	
	// Update is called once per frame
	public void Update ()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        trapFlagAction = TrapArea.GetComponent<TrapFlag>().action;

        if (trapFlagAction && kotei)
        {
            rigidbody.simulated = true;
        }

        if (StagetagColHit == true)
            {
                rigidbody.gravityScale = 20;
                if (WalltagColHit == false)
                {
                    rigidbody.velocity = Vector2.right * speed;
                }
                else
                {
                    rigidbody.velocity = Vector2.left * speed;
                }
            }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall"|| other.gameObject.tag == "MoveWall")
        {
            if (WallHitReflectionGimmick)
            {
				if (WalltagColHit == false)  WalltagColHit = true;
				
				else if(WalltagColHit) WalltagColHit = false;

			}
            else
            {
                //Debug.Log("hit");
                Destroy(this.gameObject);

            }

        }
        if(other.gameObject.tag == "Stage")
        {
            if (StageHitNoBreakDown)
            {
                StagetagColHit = true;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Out")
        {
            Destroy(this.gameObject);
        }
    }


}
