using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Sample : MonoBehaviour {

    public string url = "http://nippo.oilstand.net/test/res2.php";
    public string json = "";

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

        StartCoroutine(SetUserTest());
    }
    

    IEnumerator SetUserTest()
    {
        string fileName = "up_data.jpg";
        string filePath = Application.dataPath + "/" + fileName;
        // 画像ファイルをbyte配列に格納
        byte[] img = File.ReadAllBytes(filePath);
        

        // formにバイナリデータを追加
        WWWForm form = new WWWForm();
        form.AddBinaryData("file", img, fileName, "image/jpeg");

        using (WWW www = new WWW(url, form))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log("error:" + www.error);
                yield break;
            }
            json = www.text;
        }
    }
}
