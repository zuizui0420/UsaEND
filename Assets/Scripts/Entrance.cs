using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Entrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			// シーン遷移コルーチン開始
			StartCoroutine(GoToSceneCoroutine());
		}

	}

	private static IEnumerator GoToSceneCoroutine()
	{
		// 5秒間待つ
		yield return new WaitForSeconds(0.5f);
		// TitleSceneに遷移
		SceneManager.LoadScene("StageSelectScene");
	}
}
