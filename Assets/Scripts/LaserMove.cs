using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    GameObject childLaser;
    SpriteRenderer sr;
    //動く範囲の最小値入力
    public float minpos;
    //動く範囲の最大値入力
    public float maxpos;
    //左右反転フラグ
    private static bool flip;
    // Use this for initialization
    void Start()
    {
        flip = true;
        childLaser = transform.Find("map1_1").gameObject;
        sr = childLaser.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos, maxpos), transform.position.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);
        sr.size = new Vector2(0.5f,11.7f-hit.point.y);
    }
    private void FixedUpdate()
    {
        if (flip){
            transform.position += new Vector3(0.1f, 0, 0);
            if (transform.position.x >= maxpos)
                flip = false;
        }
        else{
            transform.position -= new Vector3(0.1f, 0, 0);
            if (transform.position.x <= minpos)
                flip = true;
        }
    }
}