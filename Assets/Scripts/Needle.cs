using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {
    bool walltouch;
    bool moveNe;
	// Use this for initialization
	void Start () {
        walltouch = true;
        moveNe = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveNe)
        {
            if (walltouch)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.4f);
                Debug.DrawRay(transform.position, transform.up * 0.4f, Color.green);

                if (hit)
                {
                    if (hit.collider.gameObject.tag == "wall")
                    {
                        StartCoroutine("stoppsge1");
                    }
                }
                else
                {
                    transform.position -= new Vector3(0.1f, 0, 0);
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.4f);
                Debug.DrawRay(transform.position, -transform.up * 0.4f, Color.red);
                if (hit)
                {
                    if (hit.collider.gameObject.tag == "wall")
                    {
                        StartCoroutine("stoppsge2");
                    }
                }
                else
                {
                    transform.position += new Vector3(0.04f, 0, 0);
                }

            }
        }
    }
    public void neel()
    {
        moveNe = true;
    }
    IEnumerator stoppsge1()
    {
        yield return new WaitForSeconds(2);
        walltouch = false;
        yield break;
    }
    IEnumerator stoppsge2()
    {
        yield return new WaitForSeconds(2);
        walltouch = true;
        yield break;
    }
}
