using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Sample : MonoBehaviour {
	
    void Start()
    {

        // データを全て取得
        //List<JsonNode> dataset =  DataControl.getAllData ();

        // jsonデータを1つ取得
        //string json = DataControl.getJson(0);

        // jsonをデコードする
        //JsonNode jsnode = DataControl.jsonDecode (json);

        // jsonに値を追加
        // string json = DataControl.jsonEncodeById(0,"review",3);

        // データを保存(第二引数に指定があればUpdate)
        //DataControl.Save(jsonString);


        // 指定したデータを削除
        //DataControl.delOneData(0);

        // データを全削除
        DataControl.delAllData ();

        /* JsonNode 使い方
		JsonNode json = JsonNode.Parse(jsonAsset.text);

		// Get<T> で型指定して取得
		string result = json["result"].Get<string>();

		// IDictionary or IListは繋げられます
		string kuroName = json["response"]["users"][0]["name"].Get<string>();

		Debug.Log(kuroName);
		*/

        // データを全て取得
        //List<JsonNode> dataset = DataControl.getAllData();
        /*
        foreach (JsonNode jn in dataset.ToArray())
        {
            foreach(var result in jn["results"])
            {
                Debug.Log(result["id"].Get<string>());
                Debug.Log(result["name"].Get<string>());

            }
        }
        */
    }
    
}
