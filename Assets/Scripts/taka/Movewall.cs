using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movewall : MonoBehaviour
{
    public float MoveWallSpeed;
    float MoveWallMoveSpeed;

    Vector2 startPos;
    Vector2 relativePos;
    Vector2 MoveWallPos;

    public bool movewall,Wallspritechange;
    public Sprite Movewallon;

	public GameObject player;

    void Start()
    {
        startPos = transform.position;
        MoveWallMoveSpeed = MoveWallSpeed / 100;
        movewall = false;
        Wallspritechange = false;
    }

    // Update is called once per frame
    void Update()
    {
		float posy;
        MoveWallPos = transform.position;
        relativePos.y = MoveWallPos.x - startPos.x;
        if (movewall == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Movewallon;
            Invoke("interval",2f);
            if (Wallspritechange == true)
            {
				posy = gameObject.GetComponent<SpriteRenderer>().size.y;

				if (0<=posy)
				{
					gameObject.GetComponent<SpriteRenderer>().size -= new Vector2(0, MoveWallMoveSpeed);
                }
                else
				{
					player.GetComponent<Player>().stpMove();
					gameObject.SetActive(false);
				}
            }
        }
        transform.position = MoveWallPos;
    }
    void interval()
    {
		Wallspritechange = true;
	}
}
