using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JsonReadWeb : MonoBehaviour {

	bool isRunning;
	public string json;

	void Start () {
		getJson();
    }

	public void getJson() {
		// コルーチン実行開始
		StartCoroutine(GetJSON());
	}

	IEnumerator GetJSON(){

		// webサーバにアクセス
		WWW www = new WWW("http://example.com/");

		// webサーバから何らかの返答があるまで停止
		yield return www;

		// エラーがあったら
		if(!string.IsNullOrEmpty(www.error)){
			Debug.LogError(string.Format("Fail Whale!\n{0}", www.error)); // エラー内容を表示
			yield break; // コルーチンを終了
		}

		// webサーバからの内容を文字列変数に格納
		json = www.text;
	}

}