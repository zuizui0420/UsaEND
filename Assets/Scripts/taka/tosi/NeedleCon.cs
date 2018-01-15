using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("NeedleMove");
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
            ne1.neel();
        }
    }
}
