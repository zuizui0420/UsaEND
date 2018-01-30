using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
	GameObject needlecon;
	public float startpos;
	public bool moveNe;
	public bool walltouch;
	public bool stops;
	// Use this for initialization
	void Start()
	{
		needlecon = transform.parent.gameObject;
		startpos = transform.position.x;
		walltouch = true;
		stops = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (moveNe && stops)
		{
			if (walltouch)
			{
				transform.position -= new Vector3(0.1f, 0, 0);
			}
			else
			{
				transform.position += new Vector3(0.04f, 0, 0);
			}
		}
	}

	IEnumerator stoppsge()
	{
		yield return new WaitForSeconds(2);
		stops = true;
		walltouch = !walltouch;
		yield break;
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Stage")
		{
			stops = false;
			StartCoroutine("stoppsge");
		}
		if (col.gameObject.tag == "Player0" || col.gameObject.tag == "Player1")
		{
			NeedleAxis nedcon = needlecon.GetComponent<NeedleAxis>();

			nedcon.needCon();
		}
	}
}