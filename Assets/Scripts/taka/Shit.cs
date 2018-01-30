using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : MonoBehaviour {
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Stage")
		{
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "Player0")
		{
			collision.gameObject.GetComponent<Player>().isDying = true;
			Destroy(gameObject);
		}
	}
}
