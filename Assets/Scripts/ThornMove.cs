using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornMove : MonoBehaviour {
    private static bool thorn;
    //動く範囲の最小値入力
    public float min;
    //動く範囲の最大値入力
    public float max;
    // Use this for initialization
    void Start () {
      
        thorn = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min, max), transform.position.y, 0);
        if (thorn)
        {
            transform.position += new Vector3(0.1f, 0, 0);
            if (transform.position.x >= max)
                thorn = false;
        }
        else
        {
            transform.position -= new Vector3(0.5f, 0, 0);
            if (transform.position.x <= min)
                thorn = true;
        }
	}
}
