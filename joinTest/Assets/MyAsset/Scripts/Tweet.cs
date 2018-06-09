using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweet : MonoBehaviour {
	public void tweet()
	{
		DataRow drone = DataControl.getOneData("id=" + SceneUtility.photoid.ToString());

		string text = "#";

		Application.OpenURL("twitter://post?message=" + WWW.EscapeURL("テスト"));
	}
}
