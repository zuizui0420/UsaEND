using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBreak : MonoBehaviour {
    public Sprite Breakladder;
    GameObject RootLadder;
    SpriteRenderer Ladder;
	// Use this for initialization
	void Start () {
        RootLadder = transform.parent.gameObject;
        Ladder = RootLadder.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.gameObject.GetComponent<Player>();
        if (col.gameObject.tag == "Player0" &&player.isClimb==true)
        {
            Ladder.sprite = Breakladder;
            if (player.isClimb == true)
            {
                player.isClimb = false;
                player.isGround = false;
            }
        }
    }
}
