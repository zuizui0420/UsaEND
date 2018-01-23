using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData {

	public static int[] VariousData; //様々データ配列
	public static int[] TrophyData;//トロフィーデータ配列

	private static string data;

	//各データ
    static int gameStart;
	static int deadCount;
	static int needleDead;

	static int GameState
	{
		get { return VariousData[0]; }
		set { VariousData[0] = value; }
	}

	static GameData()
	{

	}

	/// <summary>
	/// VariousData配列を初期化する.
	/// </summary>
	public static void InitVariousData()
	{
		for (int i = 0; i < VariousData.Length; i++)
		{
			VariousData[i] = 0;
		}

	}
}
