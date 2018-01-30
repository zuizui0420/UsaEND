using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCon : MonoBehaviour
{
	GameObject player;
	Player players;
	//GameObject player1;
	// Use this for initialization
	void Start()
	{
		StartCoroutine("NeedleMove");
		player = GameObject.FindWithTag("Player0");
		players = player.GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		if (players.isRestart)
		{
			foreach (Transform child in transform)
			{
				//Needle nee = child.GetComponent<Needle>();
				StartCoroutine("NeedleMove");
			}
		}
	}
	IEnumerator NeedleMove()
	{

		foreach (Transform child in transform)
		{
			yield return new WaitForSeconds(0.5f);
			NeedleAxis ne1 = child.GetComponent<NeedleAxis>();
			ne1.neel();
		}
	}
	public void NeedleStops()
	{
		foreach (Transform child in transform)
		{
			NeedleAxis ne1 = child.GetComponent<NeedleAxis>();
			ne1.needstop();
		}
	}
}