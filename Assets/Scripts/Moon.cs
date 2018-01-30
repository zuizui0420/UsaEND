using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.FadeIn(1, "tumiki");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left"))
		{
			transform.eulerAngles += new Vector3(0, 0, -0.5f);
		}
		else if (Input.GetKey("right"))
		{
			transform.eulerAngles += new Vector3(0, 0, 0.5f);
		}
		

	}
}
