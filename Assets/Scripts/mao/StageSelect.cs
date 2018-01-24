using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
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


    public void OnStargeButtan1Clicke()
    {
        Application.LoadLevel("StageMao");
    }

    public void MenuSceneBottan()
    {
        Application.LoadLevel("MenuScene");
    }

    public void StageSelectedButtan(int stageNom)
    {
        SceneManager.LoadScene("Stage0" + stageNom);
    }

    public void NextStageButtan()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

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
}
