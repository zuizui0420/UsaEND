using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remaincount : MonoBehaviour
{

    int cursor;

    int Dead;

    int num = 3;

    

    /// <summary>
    /// 数字スプライト配列
    /// </summary>
    public Sprite[] numbers = new Sprite[11];

    /// <summary>
    /// 残機数表示部分配列
    /// </summary>
    public SpriteRenderer[] remainRend = new SpriteRenderer[4];

    public int Digit(int num)
    {
        int digit = 1;
        for (int i = num; i >= 10; i /= 10)
        {
            digit++;
        }
        return digit;
    }

    // Use this for initialization
    void Start()
    {

        //正端君のスクリプト読み込み部分



        
 
    }

    // Update is called once per frame
    void Update()
    {

    }
}