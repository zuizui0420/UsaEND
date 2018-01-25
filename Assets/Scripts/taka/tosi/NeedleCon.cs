using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCon : MonoBehaviour {
    GameObject player;
    //GameObject player1;
    // Use this for initialization
    void Start () {
        StartCoroutine("NeedleMove");
        player = GameObject.FindWithTag("Player0" );
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator NeedleMove()
    {

        foreach (Transform child in transform)
        {
            yield return new WaitForSeconds(0.5f);
            Needle ne1 = child.GetComponent<Needle>();
            //ne1.walltouch = true;
            //ne1.stops = true;
            ne1.neel();
        }
    }
    public void NeedleStops()
    {
        foreach (Transform child in transform)
        {
            Needle needle = child.GetComponent<Needle>();
            Debug.Log("AAA");
            needle.moveNe = false;
            //needle.playerhit = true;
        }
    }
}
