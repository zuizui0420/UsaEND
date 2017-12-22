using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleAxis : MonoBehaviour {
    GameObject rootNeedle;//親オブジェクト
    SpriteRenderer sr;//自身のスプライトを入れる
    Vector3 needlpos;//position入れ
    float needspos;//移動のための初期ポジ
    float needepos;//移動先の先端ポジ
    float needmovepos;//移動量
	// Use this for initialization
	void Start () {
        rootNeedle = transform.parent.gameObject;
        needlpos = rootNeedle.transform.position;
        needspos = needlpos.x;
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update () {
       needlpos= rootNeedle.transform.position;
        needepos = needlpos.x;
        needmovepos = (needspos - needepos)*3.3f;
        sr.size+=new Vector2(needmovepos,0);
        needspos = needepos;
    }
}
