using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {
    GameObject needlecon;
    public bool moveNe;
    public bool playerhit;
    public bool walltouch;
	public bool stops;
    float startpos;
    // Use this for initialization
    void Start () {
        needlecon = transform.parent.gameObject;
        startpos = transform.position.x;
        playerhit = false;
        walltouch = true;
		stops = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveNe&&stops)
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
        //if (playerhit)
        //{
        //    if (startpos>=transform.position.x)
        //    {
        //        transform.position += new Vector3(0.1f, 0, 0);
        //    }
        //    else
        //    {
        //        NeedleCon nedcon = needlecon.GetComponent<NeedleCon>();
        //        nedcon.StartCoroutine("NeedleMove");
        //        playerhit = false;
        //    }
        //}
    }
    public void neel()
    {
        moveNe = true;
    }
    IEnumerator stoppsge()
    {
        yield return new WaitForSeconds(2);
		stops = true;
		walltouch = !walltouch;
        yield break;
    }
	private void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Wall" || col.gameObject.tag =="Stage")
		{
			stops = false;
			StartCoroutine("stoppsge");
		}
        if (col.gameObject.tag == "Player0"||col.gameObject.tag=="Player1")
        {
            NeedleCon nedcon = needlecon.GetComponent<NeedleCon>();
            stops = false;
            nedcon.NeedleStops();
        }
    }
}
