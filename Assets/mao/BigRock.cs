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
    /// 壁に当たっているか？
    /// </summary>
    bool WalltagColHit = false;

    /// <summary>
    /// 床に当たっているか？
    /// </summary>
    bool StagetagColHit = false;


    public float speed;


    GameObject TrapArea;
    bool trapFlagAction;


    // Use this for initialization
    void Start ()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine("hukusei");
        TrapArea = GameObject.Find("TrapArea");

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
        if (other.gameObject.tag == "Wall")
        {
            if (WallHitReflectionGimmick)
            {
                WalltagColHit = true;
            }
            else
            {
                Debug.Log("hit");
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


    private IEnumerator hukusei()
    {
        // ログ出力  
        Debug.Log("1");

        // 1秒待つ  
        yield return new WaitForSeconds(3.0f);

        // ログ出力  
        Debug.Log("2");


    }
}
