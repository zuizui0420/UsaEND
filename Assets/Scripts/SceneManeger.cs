using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManeger{

	static string nextSceneName;

	// Use this for initialization
	static void Start () {
		
	}
	
	// Update is called once per frame
	static void Update () {
		
	}

	public static string Property
	{
		set
		{
			 string sceneName = value;
			nextSceneName = sceneName;
		}
		get
		{
			return nextSceneName;
		}
	}

	/// <summary>
	　/// TitleSceneに遷移させるコルーチン
	　/// </summary>
	　/// <returns>The to title scene coroutine.</returns>
	private static IEnumerator GoToSceneCoroutine()
	{
		// 5秒間待つ
		yield return new WaitForSeconds(5f);
		// TitleSceneに遷移
		SceneManager.LoadScene(Property);
	}
}
