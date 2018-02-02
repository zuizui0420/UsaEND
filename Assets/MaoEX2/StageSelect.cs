using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    /// <summary>
    /// クリアしたステージ数
    /// </summary>
    public int ClearStage = 1;

    /// <summary>
    /// ステージのボタン
    /// </summary>
    public Button[] StageButtan;

    GameObject sceneManager;

    public bool FadeStart;

    int StageNom;


    //public void OnStargeButtan1Clicke()
    //{
    //    Application.LoadLevel("StageMao");
    //}

    //public void MenuSceneBottan()
    //{
    //    Application.LoadLevel("MenuScene");
    //}

    public void NextStageButtan()
    {

    }

    // Use this for initialization
    void Start()
    {
        sceneManager = GameObject.Find("FadeManager");
    }

    // Update is called once per frame
    public void Update()
    {
        FadeStart = sceneManager.GetComponent<FadeManager>().FadeStart;
        if (FadeStart)
        {
            ToNextScene();
        }

        switch (ClearStage)
        {
            case 1:
                StageButtan[ClearStage].interactable = true;
                break;

            case 2:
                StageButtan[ClearStage].interactable = true;
                break;

            case 3:
                StageButtan[ClearStage].interactable = true;
                break;

            case 4:
                StageButtan[ClearStage].interactable = true;
                break;

            case 5:
                StageButtan[ClearStage].interactable = true;
                break;

            case 6:
                StageButtan[ClearStage].interactable = true;
                break;
        }
    }

    public void StageSelectedButtan(int stageNom)
    {
        //ここでフェイドアウトを始めるよ
        sceneManager.GetComponent<FadeManager>().isFade = true;
        sceneManager.GetComponent<FadeManager>().isFadeOut = true;
        sceneManager.GetComponent<FadeManager>().gameObject.transform.SetAsLastSibling();


        StageNom = stageNom;
      
    }

    private void ToNextScene()
    {
        //シーン遷移が始める
        SceneManager.LoadScene("Stage0" + StageNom);
    }
}
