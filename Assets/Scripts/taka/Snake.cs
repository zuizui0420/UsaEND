using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    public float SnakeRightx;
    public float SnakeLeftx;
    public bool SnakeWay;
    public float SnakeSpeed;
    float SnakeMoveSpeed;

    private Vector2 startPos;
    private Vector2 relativePos;
    private Vector2 SnakePos;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
        SnakeMoveSpeed = SnakeSpeed / 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
        SnakePos = transform.position;
        relativePos.x = SnakePos.x - startPos.x;

        if (SnakeWay)
        {
            SnakePos.x += SnakeMoveSpeed;
            if (SnakeRightx <= relativePos.x)
            {
                SnakeWay = false;
                transform.Rotate(0, +180, 0);
            }
        }
        else
        {
            SnakePos.x -= SnakeMoveSpeed;
            if (SnakeLeftx >= relativePos.x)
            {
                SnakeWay = true;
                transform.Rotate(0, -180, 0);
            }
        }
        transform.position = SnakePos;
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (SnakeWay)
        {
            transform.Rotate(0, +180, 0);
            SnakeWay = false;
        }
        else
        {
            transform.Rotate(0, -180, 0);
            SnakeWay = true;
        }
    }
}
