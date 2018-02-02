using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    public int Track;

	// Use this for initialization
	void Start () {
        switch (Track)
        {
            case 1:
                AudioManager.FadeIn(0.5f, "Menubgm");
                break;
            case 2:
                AudioManager.CrossFade(0.5f, "StageSelect2");
                break;
            case 3:
                AudioManager.CrossFade(0.5f, "Stage1bgm");
                break;
            case 4:
                AudioManager.CrossFade(0.5f, "Stage2bgm");
                break;
            case 5:
                AudioManager.CrossFade(0.5f, "Stage3bgm");
                break;
            case 6:
                AudioManager.CrossFade(0.5f, "Stage4bgm");
                break;
            case 7:
                AudioManager.CrossFade(0.5f, "Stage5bgm");
                break;
            case 8:
                AudioManager.CrossFade(0.5f, "Stage6bgm");
                break;
            case 9:
                AudioManager.CrossFade(0.5f, "Stage7bgm");
                break;
            case 10:
                AudioManager.CrossFade(0.5f, "Stage8bgm");
                break;
            case 11:
                AudioManager.CrossFade(0.5f, "Stage9bgm");
                break;
            case 12:
                AudioManager.CrossFade(0.5f, "Stage10bgm");
                break;
            case 13:
                AudioManager.CrossFade(0.5f, "Clear1");
                break;
            case 14:
                AudioManager.CrossFade(0.5f, "");
                break;
            case 15:
                AudioManager.CrossFade(0.5f, "");
                break;
            case 16:
                AudioManager.CrossFade(0.5f, "");
                break;
            case 17:
                AudioManager.CrossFade(0.5f, "");
                break;
            case 18:
                AudioManager.CrossFade(0.5f, "");
                break;
            case 19:
                AudioManager.CrossFade(0.5f, "");
                break;
            case 20:
                AudioManager.CrossFade(0.5f, "");
                break;
        }



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
