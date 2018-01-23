using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;

public class StageSelect : MonoBehaviour {

    public int StageNom = 0;

    public void OnStargeButtan1Clicke()
    {
        Application.LoadLevel("StageMao");
    }

    public void MenuSceneBottan()
    {
        Application.LoadLevel("MenuScene");
    }

    public void NextStageBottan()
    {
        switch (StageNom)
        {
            case 2:
                Debug.Log("2stage");
                break;

            case 3:
                Debug.Log("3stage");
                break;

            case 4:
                Debug.Log("4stage");
                break;

            case 5:
                Debug.Log("5stage");
                break;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
