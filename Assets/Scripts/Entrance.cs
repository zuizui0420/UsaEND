using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entrance : MonoBehaviour {


    GameObject sceneManager;

    // Use this for initialization
    void Start () {
        sceneManager = GameObject.Find("FadeManager");
    }
	
	// Update is called once per frame
	void Update () {
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
        {
            sceneManager.GetComponent<FadeManager>().isFade = true;
            sceneManager.GetComponent<FadeManager>().isFadeOut = true;
            sceneManager.GetComponent<FadeManager>().gameObject.transform.SetAsLastSibling();
            // シーン遷移コルーチン開始
            StartCoroutine(GoToSceneCoroutine());
		}

	}

	private static IEnumerator GoToSceneCoroutine()
	{

        AudioManager.PlaySE("trumpet2");
        // 5秒間待つ
        yield return new WaitForSeconds(2.5f);
		// TitleSceneに遷移
		SceneManager.LoadScene("StageSelectScene");
	}
}
