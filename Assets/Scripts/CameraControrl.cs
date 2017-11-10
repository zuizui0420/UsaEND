using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControrl : MonoBehaviour {
	GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate()
	{
		Vector3 newPosition = transform.position;
		newPosition.x = player.transform.position.x + offset.x;
		newPosition.y = player.transform.position.y + offset.y;
		//transform.position = Vector3.Lerp(transform.position, newPosition, 0.8f * Time.deltaTime);
		transform.position = newPosition;
	}
}
