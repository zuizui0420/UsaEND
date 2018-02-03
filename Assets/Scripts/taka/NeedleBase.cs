using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleBase : MonoBehaviour
{

    private GameObject player;
	public GameObject needle;
	public bool NeedleSwitch;
    Vector2 needlebasepos;

    void Start()
    {
        NeedleSwitch = false;
		player = GameObject.Find("Player0");
        Instantiate(needle, this.transform.position + new Vector3(0f, -0.14f, 0), Quaternion.identity);
    }

    public void Needlefomr()           //針の生成
    {
        Instantiate(needle, this.transform.position + new Vector3(0f, -0.14f, 0), Quaternion.identity);
        NeedleSwitch = false;
        gameObject.GetComponent<Animator>().Play("StalactiteNyokisinai");
    }
}
