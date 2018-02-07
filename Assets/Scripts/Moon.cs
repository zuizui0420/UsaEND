using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left")||ButtonControl.isLeft)
		{
			transform.eulerAngles += new Vector3(0, 0, -0.5f);
		}
		else if (Input.GetKey("right")||ButtonControl.isRight)
		{
			transform.eulerAngles += new Vector3(0, 0, 0.5f);
		}
		

	}
}
