using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStartManager : Photon.MonoBehaviour{

	public bool gameStart = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		gameStart = GameObject.Find("MultiGameController").GetComponent<MultiGameControl>().gameStart;

		if (gameStart == true)
		{
			SceneManager.LoadScene("Stage01");
		}
	}

}
