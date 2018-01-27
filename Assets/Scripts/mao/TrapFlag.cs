using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFlag : MonoBehaviour {


    /// <summary>
    /// プレイヤーの位置に合わせて作動させるか？
    /// </summary>
    public bool TrapGimmick;

    public bool action = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player0")
        {
            Debug.Log("hit");
            if (TrapGimmick)
            {
                action = true;
            }
        }
    }
}
