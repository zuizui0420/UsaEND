using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    //動く範囲の最小値入力
    public float minpos;
    //動く範囲の最大値入力
    public float maxpos;
    private static bool flip;
    // Use this for initialization
    void Start()
    {
        flip = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos, maxpos), transform.position.y, 0);
    }
    private void FixedUpdate()
    {
        if (flip){
            transform.position += new Vector3(0.1f, 0, 0);
            if (transform.position.x >= maxpos)
                flip = false;
        }
        else{
            transform.position -= new Vector3(0.1f, 0, 0);
            if (transform.position.x <= minpos)
                flip = true;
        }
    }
}