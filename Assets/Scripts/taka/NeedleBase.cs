using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleBase : MonoBehaviour
{

    private GameObject player;
	public GameObject needle;


	public bool NeedleSwitch;

    void Start()
    {
        NeedleSwitch = false;
		player = GameObject.Find("Player0");
	}

    public void Needlefomr()           //針の生成
    {
        Instantiate(needle, this.transform.position, Quaternion.identity);
        NeedleSwitch = false;
        gameObject.GetComponent<Animator>().Play("StalactiteNyokisinai");
    }
}
