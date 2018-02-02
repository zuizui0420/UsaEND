using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{


    // フェードに利用する画像保存用変数
    public Image FadeImage;


    // フェードスイッチ
    public bool isFade;
    // フェードインフラグ
    public bool isFadeIn;
    // フェードアウトフラグ
    public bool isFadeOut;
    // アルファ値
    float alpha;
    //Scene切り替えフラグ
    public bool FadeStart;

    //Playerのゲームオブジェクト入れるための器
    GameObject player;


    void Start()
    {
        // シーン開始時はフェードインから始まる
        isFade = true;  // フェードON
        isFadeIn = true;  // フェードインON
        isFadeOut = false; // フェードアウトOFF
        alpha = 1.0f;  // 100％不透明

        //PLAYER見つけて移す
        player = GameObject.Find("LoadingUsa");

        // 最前面へ
        this.transform.SetAsLastSibling();

        // 画像のアルファ値をセット
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);
    }

    void Update()
    {
        if (isFade == true)
        {
            if (isFadeIn == true)
            {
                FadeIn();    // フェードイン
            }
            if (isFadeOut == true)
            {
                FadeOut();    // フェードアウト
            }
        }
        else
        {
            // Eneterキーでフェードアウト開始し、終了後シーン遷移
            //if (Input.GetKey(KeyCode.Return))
            //{
            //    isFade = true;                   // フェードフラグON
            //    isFadeOut = true;                   // フェードアウトフラグON
            //    this.transform.SetAsLastSibling();  // 最前面へ
            //}
        }
    }

    // フェードイン（透明にしていく）
    void FadeIn()
    {
        // 計算用アルファ値を減算
        alpha -= 0.04f;

        // 画像のアルファ値を変更
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);

        // アルファ値がMIN値以下になったら
        if (FadeImage.color.a <= 0.0f)
        {
            isFade = false;                      // フェードスイッチOFF
            isFadeIn = false;                      // フェードインフラグOFF
            isFadeOut = true;
            this.transform.SetAsFirstSibling();    // 最背面へ
        }
    }

    // フェードアウト（不透明にしていく）
    void FadeOut()
    {
        alpha += 0.04f; // 計算用アルファ値を加算

        // 画像のアルファ値を変更
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);



        // アルファ値がMAX値以上になったら
        if (FadeImage.color.a >= 1.0f)
        {
            isFade = false;                        // フェードスイッチOFF
            isFadeOut = false;

            StartCoroutine("LoadingTime");
        }
    }
    private IEnumerator LoadingTime()
    {

        player.GetComponent<LoadingWalk>().go = true;
		AudioManager.PlaySE("trumpet2");
		yield return new WaitForSeconds(2f);
        FadeStart = true;// フェードアウトフラグOFF
    }
}