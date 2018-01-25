using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSide : MonoBehaviour {
    public float settime;
    GameObject childLaser;
    SpriteRenderer sr;
    bool Laserstop;
    // Use this for initialization
    void Start () {
        childLaser = transform.Find("map1_1").gameObject;
        sr = childLaser.GetComponent<SpriteRenderer>();
        StartCoroutine("laserstop");
        Laserstop = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Laserstop)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);
            Debug.Log(hit.collider.tag);
            float posAbs = System.Math.Abs(transform.position.x);
            sr.size = new Vector2(0.5f, posAbs + hit.point.x);
            if (hit.collider.tag == "Player0")
            {
                //プレイヤーの死亡イベント読み込み
            }
        }
    }
    IEnumerator laserstop()
    {
        yield return new WaitForSeconds(settime);
        Laserstop = !Laserstop;
        sr.size = new Vector2(0.5f, 0);
        StartCoroutine("laserstop");
    }
}
