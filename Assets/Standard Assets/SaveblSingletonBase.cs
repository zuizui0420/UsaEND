using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System;

abstract public class SaveblSingletonBase<T>where T : SaveblSingletonBase<T>,new()
{
	protected static T instance;
	bool isLoaded = false;
	protected bool isSaving = false;

	public static T Instance
	{
		get
		{
			if (null == instance)
			{
				//セーブパスか存在するなら読み込んでないなら作る
				var json = File.Exists(GetSavePath()) ? File.ReadAllText(GetSavePath()) : "";
				if (json.Length > 0)
				{
					LoadFromJSON(json);
					Debug.Log(json);
				}
				else
				{
					instance = new T();
					instance.isLoaded = true;
					instance.PostLoad();
					Debug.Log("null");
				}
			}
			return instance;
		}
	}

	protected virtual void PostLoad()
	{
	}

	public void Save()
	{
		if (isLoaded)
		{
			isSaving = true;
			var path = GetSavePath();
			File.WriteAllText(path, JsonUtility.ToJson(this));
#if UNITY_IOS
            // iOSでデータをiCloudにバックアップさせない設定
            UnityEngine.iOS.Device.SetNoBackupFlag(path);
#endif
			isSaving = false;
		}
	}

	public void Reset()
	{
		instance = null;
	}

	public void Clear()
	{
		if (File.Exists(GetSavePath()))
		{
			File.Delete(GetSavePath());
		}
		instance = null;
	}

	public static void LoadFromJSON(string json)
	{
		try
		{
			instance = JsonUtility.FromJson<T>(json);//呼び出した先ではinstance.変数名で各変数を使える
			instance.isLoaded = true;
			instance.PostLoad();
		}
		catch (Exception e)
		{
			Debug.Log(e.ToString());
		}
	}

	static string GetSavePath()
	{
		return string.Format("{0}/{1}", Application.persistentDataPath, GetSaveKey());
	}

	static string GetSaveKey()
	{
		var provider = new SHA1CryptoServiceProvider();
		return provider.ComputeHash(System.Text.Encoding.ASCII.GetBytes(typeof(T).FullName)).ToString();
	}

}
