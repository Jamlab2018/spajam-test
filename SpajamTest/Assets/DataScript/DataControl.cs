using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

/// <summary>
/// データ保存及び取得
/// </summary>
public class DataControl : MonoBehaviour {
	
	//------------------------------------------
	/// <summary>
	/// Json分解
	/// </summary>
	/// <returns>The decode.</returns>
	/// <param name="json">Json.</param>
	//------------------------------------------
	public static JsonNode jsonDecode(string json) {
		//Dictionary<string,object> data = Json.Deserialize (json) as Dictionary<string, object>;
		JsonNode node = JsonNode.Parse(json);
		return node;
	}

	//------------------------------------------
	/// <summary>
	/// Json値追加
	/// </summary>
	/// <returns>The encode by identifier.</returns>
	/// <param name="id">Identifier.</param>
	/// <param name="key">Key.</param>
	/// <param name="value">Value.</param>
	//------------------------------------------
	public static string jsonEncodeById(int id, string key, string value) {
		string oldjson = DataControl.getJson (id);
		Dictionary<string,object> data = Json.Deserialize (oldjson) as Dictionary<string, object>;
		data[key] = value;

		string json = "";
		json = Json.Serialize (data);

		return json;
	}

	//------------------------------------------
	/// <summary>
	/// json型の値を保存
	/// </summary>
	/// <param name="id">ユニークID</param>
	/// <param name="json">Json.</param>
	//------------------------------------------
	public static int Save(string json, int id = -1) {
		
		// 連番取得
		if (id < 0) {
			id = PlayerPrefs.GetInt ("increment");
		}

		// データ保存
		PlayerPrefs.SetString (id.ToString(), json);

		// 連番保存 
		id++;
		PlayerPrefs.SetInt ("increment", id);

		return 1;
	}

	//------------------------------------------
	/// <summary>
	/// Jsonの値を取得
	/// </summary>
	/// <returns>The json.</returns>
	/// <param name="id">Identifier.</param>
	//------------------------------------------
	public static string getJson( int id ){
		return PlayerPrefs.GetString(id.ToString());
	}

	//------------------------------------------
	/// <summary>
	/// 連番保存
	/// </summary>
	/// <param name="id">Identifier.</param>
	//------------------------------------------
	private void setIncrement(int id) {
		PlayerPrefs.SetInt ("increment", id);
	}

	//------------------------------------------
	/// <summary>
	/// 全情報取得
	/// </summary>
	/// <returns>The all data.</returns>
	//------------------------------------------
	public static List<JsonNode> getAllData(){

		List<JsonNode> dataset = new List<JsonNode>(0);

		int id = PlayerPrefs.GetInt ("increment");

		for (int i = 0; i < PlayerPrefs.GetInt ("increment"); i++) {
			string json = DataControl.getJson (i);
			if (json.Equals ("")) {
				continue;
			}
			// Dictionary<string,object>型変数に値を格納する
			JsonNode data = DataControl.jsonDecode (json);

			dataset.Add(data);
		}
		return dataset;
	}


	/// <summary>
	/// データを全削除
	/// </summary>
	public static void delAllData(){
		PlayerPrefs.DeleteAll ();
	}

	/// <summary>
	/// データを削除　key指定
	/// </summary>
	public static void delOneData(int id){
		PlayerPrefs.DeleteKey (id.ToString ());
	}
}
