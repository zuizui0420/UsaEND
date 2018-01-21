using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControrl : MonoBehaviour {
	GameObject player;
	private Vector3 offset;
	public Transform anchorTopLeft;
	public Transform anchorBottomRight;

	int actID = 0;//ルーム内のプレイヤーID

	void Awake()
	{
		try {

			actID = GameObject.Find("PhotonManager").GetComponent<PhotonManager>().actID;

		}
		catch {
			actID = 0;
		}
		
	}

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindWithTag("Player"+actID);
	}
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		TrackPlayer();
	
	}


	void TrackPlayer()
	{
		Vector3 newPosition = transform.position;
		newPosition.x = player.transform.position.x;
		newPosition.y = player.transform.position.y;
		//transform.position = Vector3.Lerp(transform.position, newPosition, 0.8f * Time.deltaTime);

		//
		Vector3 diffPos = newPosition - transform.position;

		Vector3 topLeft = diffPos + Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0.0f));
		Vector3 bottomRight = diffPos + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0.0f));

		Vector3 topLeftDiff = anchorTopLeft.position - topLeft;
		Vector3 bottomRightDiff = anchorBottomRight.position - bottomRight;


		if (topLeftDiff.x >= 0) newPosition.x += topLeftDiff.x;
		if (topLeftDiff.y <= 0) newPosition.y += topLeftDiff.y;
		if (bottomRightDiff.x <= 0) newPosition.x += bottomRightDiff.x;
		if (bottomRightDiff.y >= 0) newPosition.y += bottomRightDiff.y;

		//if (topLeft.y < anchorTopLeft.position.y) newPosition.y = topLeft.y; ;
		//if (bottomRight.x > anchorBottomRight.position.x) newPosition.x = topLeft.x;
		//if (bottomRight.y > anchorBottomRight.position.y) newPosition.x = topLeft.x;

		transform.position = newPosition;
	}
}
