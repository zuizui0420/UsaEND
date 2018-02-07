using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyTouch : MonoBehaviour {
    RectTransform back_ground;
    float downPos;
    float touchPos;
    // Use this for initialization
    void Start () {
        back_ground = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            touchPos = Input.mousePosition.y;
            if (Input.GetMouseButtonDown(0))
            {
                downPos = Input.mousePosition.y;
            }
        }
        float TouchMove = touchPos - downPos;
        downPos = touchPos;
        float moveY = back_ground.anchoredPosition.y + TouchMove;

        back_ground.anchoredPosition = new Vector2(0, Mathf.Clamp(moveY, -750, 1500));//二つの間の値にする
    }
}
