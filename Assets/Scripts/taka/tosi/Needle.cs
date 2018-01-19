using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {
    bool walltouch;
    bool moveNe;
	bool stpps;
	// Use this for initialization
	void Start () {
        walltouch = true;
        moveNe = false;
		stpps = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveNe&&stpps)
        {
            if (walltouch)
            {
                    transform.position -= new Vector3(0.1f, 0, 0);
            }
            else
            {
                    transform.position += new Vector3(0.04f, 0, 0);
            }
        }
    }
    public void neel()
    {
        moveNe = true;
    }
    IEnumerator stoppsge()
    {
        yield return new WaitForSeconds(2);
		stpps = true;
		walltouch = !walltouch;
        yield break;
    }
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Wall")
		{
			stpps = false;
			StartCoroutine("stoppsge");
		}
	}
}
