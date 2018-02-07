using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleYatu : MonoBehaviour
{
    public float Needlex;
    public bool NeedleWay;
    public float NeedleSpeed;
    float NeedleMoveSpeed;

    private Vector2 startPos;
    private Vector2 relativePos;
    private Vector2 NeedlePos;
    private Vector2 NeedleDifference;
    private Vector2 NeedleSpriteSize;

    private float timeleft;
    public float Interval;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        NeedleMoveSpeed = NeedleSpeed / 100;
        NeedleSpriteSize = GetComponent<SpriteRenderer>().size;
    }

    // Update is called once per frame
    void Update()
    {
        NeedlePos = transform.position;
        relativePos.x = NeedlePos.x - startPos.x;
        if (NeedleWay == true)
        {
            if (0 <= relativePos.x)
            {
                NeedleInterval();
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().size -= new Vector2(NeedleMoveSpeed, 0);
                NeedlePos.x += NeedleMoveSpeed;
            }
        }
        else if(NeedleWay ==false)
        {
            if (-Needlex >= relativePos.x)
            {
                NeedleInterval();
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().size += new Vector2(NeedleMoveSpeed, 0);
                NeedlePos.x -= NeedleMoveSpeed;
            }
        }
        transform.position = NeedlePos;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            if (NeedleWay)
            {
                NeedleInterval();
            }
            else
            {
                NeedleInterval();
            }
        }
    }
    public void NeedleInterval()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0f)
        {
            if (NeedleWay)
            {

                NeedleWay = false;
                timeleft = Interval;
            }
            else
            {

                NeedleWay = true;
                timeleft = Interval;
            }
        }
    }
}
