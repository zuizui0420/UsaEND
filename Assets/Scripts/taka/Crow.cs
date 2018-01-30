using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour {
    GameObject player;
    public GameObject unti;

    public float CrowRightx;    //右のmax値
    public float CrowLeftx;     //左のmax値
    public bool CrowWay ;
    public float CrowSpeed;
    float CrowMoveSpeed;

    private Vector2 startPos;
    private Vector2 relativePos;
    private Vector2 CrowPos;
    private Vector2 playerPos;

    private float timeleft;
    public float UntiInterval;


    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        CrowMoveSpeed = CrowSpeed / 100;

		player = GameObject.FindWithTag("Player0");
    }
	// Update is called once per frame
	void Update ()
    {
        CrowPos = transform.position;
        relativePos.x = CrowPos.x-startPos.x;
        playerPos = player.transform.position;
        if (CrowWay)
        {
            CrowPos.x += CrowMoveSpeed;
            if (CrowRightx <= relativePos.x )
            {

                transform.Rotate(0, +180, 0);
                CrowWay = false;
            }
        }
        else
        {
            CrowPos.x -= CrowMoveSpeed;
            if (CrowLeftx >= relativePos.x)
            {
                transform.Rotate(0, -180, 0);
                CrowWay = true;
            }
        }
        transform.position = CrowPos;
        unko();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("かべあたったよぉ");
        if (CrowWay)
        {
            transform.Rotate(0, +180, 0);
            CrowWay = false;
        }
        else
        {
            transform.Rotate(0, -180, 0);
            CrowWay = true;
        }

    }
    public void unko()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0f)
        {
            timeleft = UntiInterval;
            if (playerPos.x - 2 <= CrowPos.x && playerPos.x + 2 >= CrowPos.x)
            {
                Crowunko();
            }
        }
    }

    public void Crowunko()
    {
        Instantiate(unti, this.transform.position, Quaternion.identity);
    }
}
