﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

/// <summary>
/// 音の管理をする
/// </summary>
public sealed class AudioManager : SingletonMonoBehaviour<AudioManager> {

	const string MIXER_PATH = "Sounds/MainAudioMixer";		//ミキサーのパス
	const string BGM_PATH = "Sounds/BGM/";					//BGMのフォルダーパス
	const string SE_PATH = "Sounds/SE/";                    //SEのフォルダーパス

	public AudioMixer mixer { get; private set; }			//ミキサー

	AudioMixerGroup[] mixerGroups = new AudioMixerGroup[2];	//ミキサーのグループ [0]SE [1]BGM

	Dictionary<string, AudioClip> SEclips;					//再生用リスト
	Dictionary<string, AudioClip> BGMclips;					//再生用リスト

	AudioSource nowPlayingBGM;								//現在再生されているBGM
	string latestPlayBGM = "";								//再生されているBGMの種類

	Coroutine fadeInCol;									//BGMフェードインのコルーチン
	AudioSource fadeInAudio;								//BGMフェードイン用のAudioSource

	protected override void Init() {
		base.Init();

		Load();
	}

	/// <summary>
	/// 各音情報を読み込み
	/// </summary>
	public static void Load() {

		//LoadMixer
		var mixer = Resources.Load<AudioMixer>(MIXER_PATH);
		if(mixer) {
			instance.mixerGroups[0] = mixer.FindMatchingGroups("SE")[0];
			instance.mixerGroups[1] = mixer.FindMatchingGroups("BGM")[0];
		}
		else {
			Debug.LogError("Failed Load AudioMixer! Path=" + MIXER_PATH);
		}


		//BGM読み込み
		instance.BGMclips = new Dictionary<string, AudioClip>();
		foreach(var item in Resources.LoadAll<AudioClip>(BGM_PATH)) {
			instance.BGMclips.Add(item.name, item);
		}

		//SE読み込み
		instance.SEclips = new Dictionary<string, AudioClip>();
		foreach(var item in Resources.LoadAll<AudioClip>(SE_PATH)) {
			instance.SEclips.Add(item.name, item);
		}

	}

	/// <summary>
	/// SEを再生する
	/// </summary>
	/// <param name="type">SEの名前</param>
	/// <param name="vol">音量</param>
	/// <param name="autoDelete">再生終了時にSEを削除するか</param>
	/// <returns>再生しているSE</returns>
	public static AudioSource PlaySE(string SEName, float vol = 1.0f, bool autoDelete = true) {

		//SE取得
		var clip = GetSE(SEName);
		if(!clip) return null;

		var src = new GameObject("[Audio SE - " + SEName + "]").AddComponent<AudioSource>();
		src.transform.SetParent(instance.transform);
		src.clip = clip;
		src.volume = vol;
		src.outputAudioMixerGroup = instance.mixerGroups[0];
		src.Play();

		if(autoDelete)
			Destroy(src.gameObject, src.clip.length + 0.1f);

		return src;

	}

	/// <summary>
	/// BGMを再生する
	/// </summary>
	/// <param name="BGMName">BGMの名前</param>
	/// <param name="vol">音量</param>
	/// <param name="isLoop">ループ再生するか</param>
	/// <returns>再生しているSE</returns>
	public static AudioSource PlayBGM(string BGMName, float vol = 1.0f, bool isLoop = true) {

		//BGM取得
		var clip = GetBGM(BGMName);
		if(!clip) return null;
		if(instance.nowPlayingBGM) Destroy(instance.nowPlayingBGM.gameObject);

		var src = new GameObject("[Audio BGM - " + BGMName + "]").AddComponent<AudioSource>();
		src.transform.SetParent(instance.transform);
		src.clip = clip;
		src.volume = vol;
		src.outputAudioMixerGroup = instance.mixerGroups[1];
		src.Play();

		if(isLoop) {
			src.loop = true;
		}
		else {
			Destroy(src.gameObject, clip.length + 0.1f);
		}

		instance.nowPlayingBGM = src;
		instance.latestPlayBGM = BGMName;

		return src;
	}

	/// <summary>
	/// BGMをフェードインさせる
	/// </summary>
	/// <param name="fadeTime">フェードする時間</param>
	/// <param name="type">新しいBGMのタイプ</param>
	/// <param name="vol">新しいBGMの大きさ</param>
	/// <param name="isLoop">新しいBGMがループするか</param>
	public static void FadeIn(float fadeTime, string BGMName, float vol = 1.0f, bool isLoop = true) {
		instance.fadeInCol = instance.StartCoroutine(instance.FadeInAnim(fadeTime, BGMName, vol, isLoop));
	}

	/// <summary>
	/// BGMをフェードアウトさせる
	/// </summary>
	/// <param name="fadeTime">フェードする時間</param>
	public static void FadeOut(float fadeTime) {
		instance.StartCoroutine(instance.FadeOutAnim(fadeTime));
	}

	/// <summary>
	/// BGMをクロスフェードする
	/// </summary>
	/// <param name="fadeTime">フェードする時間</param>
	/// <param name="type">新しいBGMのタイプ</param>
	/// <param name="vol">新しいBGMの大きさ</param>
	/// <param name="isLoop">新しいBGMがループするか</param>
	public static void CrossFade(float fadeTime, string fadeInBGMName, float vol = 1.0f, bool isLoop = true) {
		instance.StartCoroutine(instance.FadeOutAnim(fadeTime));
		instance.fadeInCol = instance.StartCoroutine(instance.FadeInAnim(fadeTime, fadeInBGMName, vol, isLoop));
	}

	/// <summary>
	/// SEを取得する
	/// </summary>
	/// <param name="SEName">SEの名前</param>
	/// <returns>SE</returns>
	static AudioClip GetSE(string SEName) {

		if(!instance.SEclips.ContainsKey(SEName)) {
			Debug.LogError("SEName:" + SEName + " is not found.");
			return null;
		}
		return instance.SEclips[SEName];
	}

	/// <summary>
	/// BGMを取得する
	/// </summary>
	/// <param name="BGMName">BGMの名前</param>
	/// <returns>BGM</returns>
	static AudioClip GetBGM(string BGMName) {

		if(!instance.BGMclips.ContainsKey(BGMName)) {
			Debug.LogError("BGMName:" + BGMName + " is not found.");
			return null;
		}
		return instance.BGMclips[BGMName];
	}

	IEnumerator FadeInAnim(float fadeTime, string BGMName, float vol, bool isLoop) {

		//BGM取得
		var clip = GetBGM(BGMName);
		if(!clip) yield break;

		//初期設定
		fadeInAudio = new GameObject("[Audio BGM - " + BGMName + " - FadeIn ]").AddComponent<AudioSource>();
		fadeInAudio.transform.SetParent(instance.transform);
		fadeInAudio.clip = clip;
		fadeInAudio.volume = 0;
		fadeInAudio.outputAudioMixerGroup = mixerGroups[1];
		fadeInAudio.Play();

		//フェードイン
		var t = 0.0f;
		while((t += Time.deltaTime / fadeTime) < 1.0f) {
			fadeInAudio.volume = t * vol;
			yield return null;
		}

		fadeInAudio.volume = vol;
		fadeInAudio.name = "[Audio BGM - " + BGMName + "]";

		if(nowPlayingBGM) Destroy(nowPlayingBGM.gameObject);

		if(isLoop) {
			fadeInAudio.loop = true;
		}
		else {
			Destroy(fadeInAudio.gameObject, clip.length + 0.1f);
		}

		nowPlayingBGM = fadeInAudio;
	}

	IEnumerator FadeOutAnim(float fadeTime) {

		var src = nowPlayingBGM;

		//フェードイン中にフェードアウトが呼ばれた場合
		if (!src) {
			//フェードイン処理停止
			instance.StopCoroutine(fadeInCol);
			src = fadeInAudio;
		}

		src.name = "[Audio BGM - " + latestPlayBGM + " - FadeOut ]";
		nowPlayingBGM = null;

		//フェードアウト
		var t = 0.0f;
		float vol = src.volume;
		while((t += Time.deltaTime / fadeTime) < 1.0f) {
			src.volume = (1 - t) * vol;
			yield return null;
		}

		Destroy(src.gameObject);
	}
}
