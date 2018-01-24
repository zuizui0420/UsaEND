using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[SerializeField]
public class GameData : SaveblSingletonBase<GameData>
{
	string jsonData;

	//各データ
	[SerializeField]	
    int gameStart;
	[SerializeField]
	int deadCount;
	[SerializeField]
	int needleDead;

	public int GameStart
	{
		get { return gameStart; }
		set { gameStart = value; }

	}
	public int DeadCount
	{
		get { return deadCount; }
		set { deadCount = value; }

	}

	public int NeedDead
	{
		get { return needleDead; }
		set { needleDead = value; }
	}

}
