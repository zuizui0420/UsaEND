using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleAxis : MonoBehaviour {
    GameObject childNeedle;//子オブジェクト
    GameObject rootObj;
    SpriteRenderer sr;//自身のスプライトを入れる
    BoxCollider2D col2d;
    Vector3 needlpos;//position入れ
    float needspos;//移動のための初期ポジ
    float needepos;//移動先の先端ポジ
    float needmovepos;//移動量
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        col2d = GetComponent<BoxCollider2D>();
        rootObj = transform.parent.gameObject;
        foreach (Transform child in transform)
        {
            childNeedle = child.transform.gameObject;
        }
        needlpos = childNeedle.transform.position;
        needspos = needlpos.x;
    }
    // Update is called once per frame
    void Update () {
       needlpos= childNeedle.transform.position;
        needepos = needlpos.x;
        needmovepos = (needspos - needepos)*3.3f;
        sr.size+=new Vector2(needmovepos,0);
       col2d.size+= new Vector2(needmovepos, 0);
        col2d.offset-=new Vector2(needmovepos/1.8f,0);
        needspos = needepos;
    }
    public void neel()
    {
        foreach (Transform child in transform)
        {
            Needle ne1 = child.GetComponent<Needle>();
            ne1.moveNe = true;
            ne1.walltouch = true;
            ne1.stops = true;
            ne1.transform.position = new Vector3(ne1.startpos, ne1.transform.position.y);
        }
    }
    public void needstop()
    {
        foreach (Transform child in transform)
        {
            Needle ne1 = child.GetComponent<Needle>();
            ne1.moveNe = false;
        }
    }
    public void needCon()
    {
        NeedleCon nee = rootObj.GetComponent<NeedleCon>();
        nee.NeedleStops();
    }
}
