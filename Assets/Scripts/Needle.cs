using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {
    Vector3 pos;
	// Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2f);
          Debug.DrawRay(transform.position, transform.right* 2f, Color.green);
        if (hit)
        {

        }
    }
}
