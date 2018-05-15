using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HttpRequestManager : MonoBehaviour
{
    // URL
    string url = "http://nippo.oilstand.net/test/res2.php";
    void Start()
    {
        connectionStart();  // GET
    }

    public void connectionStart()
    {
        string fileName = "hoge.jpg";
        string filePath = Application.dataPath + "/" + fileName;

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
        
        WWW www = new WWW(url, form);
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
        }
    }
}