using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleDrop : MonoBehaviour
{
    private GameObject player,needlebase;


    private float timeleft;

    private Vector2 startPos;
    private Vector2 relativePos;
    private Vector2 NeedlePos;
    private Vector2 playerPos;

    public float right,left,top,under;

    void Start()
    {
        player = GameObject.Find("Player0");
        needlebase = GameObject.Find("Stalactite");
    }
    void Update()
    {
        NeedlePos = transform.position;
        playerPos = player.transform.position;
        Needldrop();
    }


    void Needldrop()
    {
        if ((NeedlePos.x + right) >= playerPos.x && (NeedlePos.x - left) <= playerPos.x &&
            (NeedlePos.y + top) >= playerPos.y && (NeedlePos.y - under) <= playerPos.y)
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("NeedleDestroy", 0.2f);
		if(collision.gameObject.tag == "Player0")
		{
			DieEvent();
		}
	}

    public void NeedleDestroy()
	{
		needlebase.GetComponent<Animator>().Play("StalactiteNyoki");
        Destroy(gameObject);
    }
	void DieEvent()
	{
		player.GetComponent<Player>().isDying = true;
		needlebase.GetComponent<Animator>().Play("StalactiteNyoki");
		Destroy(gameObject);
	}
}
