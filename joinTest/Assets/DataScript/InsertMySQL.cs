using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertMySQL : MonoBehaviour {

	//------------------------------------------------
	/// <summary>
	/// プレースAPI用処理開始
	/// </summary>
	/// <param name="place_id">Place identifier.</param>
	//------------------------------------------------
	public void connectionStart(string json, float gps_x, float gps_y)
	{
		string url = "https://shimesabawebplayer.appspot.com/post.php"; // URL
		JsonNode jn = DataControl.jsonDecode(json);

		WWWForm form = new WWWForm();
		//"file"というkeyで上で読み込んだファイルのバイナリを送信ファイル形式は"image/png"

		int datid = DataControl.getMaxId () == 0 ? 1 : DataControl.getMaxId ();


		string query = "INSERT INTO maindata VALUES(100," +
			datid.ToString() + "," +
			"'" + jn["result"]["name"].Get<string>() + "'," +
			"'" + jn["result"]["formatted_address"].Get<string>() + "'," +
			"'" + jn["result"]["formatted_phone_number"].Get<string>() + "'," +
			jn["result"]["rating"].Get<double>() + "," +
			"0," +
			"''," +
			"''," +
			"''," +
			"''," +
			"''," +
			"''," +
			"''," +
			"'" + jn["result"]["place_id"].Get<string>() + "'," +
			"'"+gps_x.ToString()+"',"+
			"'"+gps_y.ToString()+"'"+
			");";
		
		form.AddField("request", query);
		WWW www = new WWW(url, form);

		StartCoroutine("WaitForRequest", www);
	}

	//------------------------------------------------
	/// <summary>
	/// リクエストを待つ
	/// </summary>
	/// <returns>The for place request.</returns>
	/// <param name="www">Www.</param>
	//------------------------------------------------
	private IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		connectEnd(www);
	}

	//------------------------------------------------
	/// <summary>
	/// 通信終了後の処理.
	/// </summary>
	/// <param name="www">Www.</param>
	//------------------------------------------------
	private void connectEnd(WWW www)
	{
		//通信結果をLogで出す
		if (www.error != null)
		{
			//エラー内容 -> www.error
			Debug.Log(www.error);
		}
		else
		{
			//通信結果 -> www.text
			Debug.Log(www.text);
		}
	}
}
