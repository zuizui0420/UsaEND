using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {
    public Sprite Breakground;//壊れあた後のsprite
    SpriteRenderer sprites;
    // Use this for initialization
    void Start () {
        sprites = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player0")
        {
            StartCoroutine("groundBreak");
        }
    }
    IEnumerator groundBreak()
    {
        yield return new WaitForSeconds(0.3f);
        sprites.sprite = Breakground;//sprite変更
        GetComponent<BoxCollider2D>().enabled = false;//コライダー消す
    }
}
