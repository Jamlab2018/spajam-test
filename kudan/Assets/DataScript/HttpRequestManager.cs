using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HttpRequestManager : MonoBehaviour
{
    // URL
    public GameObject text;
    Text post;
    string url = "http://nippo.oilstand.net/test/res.php";
    public void Post(float x,float y)
    {
        connectionStart(x,y);// GET
    }

    public void connectionStart(float gps_x,float gps_y)
    {
        string date = DateTime.Now.ToString("yyyyMMddhhmm");
        string fileName = date+".jpg";
        string filePath = Application.dataPath + "/" + fileName;
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
        filePath = Application.persistentDataPath+"/photo/" + fileName;
#endif

        Debug.Log("x"+gps_x+"\n");
        Debug.Log("y" + gps_y + "\n");


        System.IO.FileStream fs = new System.IO.FileStream(filePath,
                                                           System.IO.FileMode.Open,
                                                           System.IO.FileAccess.Read);
        //ファイルを読み込むバイト型配列を作成する
        byte[] bytes = new byte[fs.Length];
        //ファイルの内容をすべて読み込む
        fs.Read(bytes, 0, bytes.Length);
        //閉じる
        fs.Close();
        WWWForm form = new WWWForm();
        //"file"というkeyで上で読み込んだファイルのバイナリを送信、ファイル名は"sample.png"、ファイル形式は"image/png"
        form.AddBinaryData("up_file", bytes, fileName, "image/jpg");
        form.AddField("gps_x", gps_x.ToString());
        form.AddField("gps_y", gps_y.ToString());
        WWW www = new WWW(url, form);

        post = text.GetComponent<Text>();
        post.text = "x:" + gps_x.ToString() + ":y=" + gps_y.ToString();

        StartCoroutine("WaitForRequest", www);
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        connectionEnd(www);
    }

    //通信終了後の処理
    private void connectionEnd(WWW www)
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
            post = text.GetComponent<Text>();
            post.text = www.text.ToString();
            DataControl.dataInsert(www.text);
            DataTable dt = DataControl.getData();
            foreach(DataRow dr in dt.Rows)
            {
                Debug.Log(dr.Count);
            }
        }
    }
}