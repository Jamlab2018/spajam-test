using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweet : MonoBehaviour {
	public void Share()
    {
		DataRow drone = DataControl.getOneData("id=" + SceneUtility.photoid.ToString());

         // Shareするメッセージを設定
        string text ="#ミテコレ\n ";

		text += "名称：" + drone ["name"].ToString () + "\n";
		text += "レーティング：" + drone["rating"].ToString().ToString () + "\n";
		text += "電話番号：" + drone["phone_number"].ToString() + "\n";
		text += "所在地：" + drone["address"].ToString() + "\n";
		text += "\n";
		text += "コメント：" + drone["mycomment"].ToString() + "\n";
		text += "マイレーティング：" + drone["myrating"].ToString().ToString () + "\n";

		Application.OpenURL("twitter://post?message=" + WWW.EscapeURL(text));
    }
}
