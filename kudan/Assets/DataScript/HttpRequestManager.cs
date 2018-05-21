using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HttpRequestManager : MonoBehaviour
{
    // URL
    public GameObject text;
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
        string ido = "26.2606552";
        string kedo = "127.7577408"
;#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
        filePath = Application.persistentDataPath+"/photo/" + fileName;
#endif
        Debug.Log("x"+gps_x+"\n");
        Debug.Log("y" + gps_y + "\n");
        Text posttext = text.GetComponent<Text>();
        //posttext.text ="1";
        System.IO.FileStream fs = new System.IO.FileStream(filePath,
                                                           System.IO.FileMode.Open,
                                                           System.IO.FileAccess.Read);
        posttext.text = "2";
        //ファイルを読み込むバイト型配列を作成する
        byte[] bytes = new byte[fs.Length];
        posttext.text = "3";
        //ファイルの内容をすべて読み込む
        fs.Read(bytes, 0, bytes.Length);
        posttext.text = "4";
        //閉じる
        fs.Close();
        posttext.text = "5";
        WWWForm form = new WWWForm();
        posttext.text = "6";
        //"file"というkeyで上で読み込んだファイルのバイナリを送信、ファイル名は"sample.png"、ファイル形式は"image/png"
        form.AddBinaryData("up_file", bytes, fileName, "image/jpg");
        posttext.text = "7";
        form.AddField("gps_x", ido/*gps_x.ToString()*/);
        posttext.text = "8";
        form.AddField("gps_y", kedo/*gps_y.ToString()*/);
        posttext.text = "9";
        WWW www = new WWW(url, form);
        posttext.text = "10";
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
        Text posttext = text.GetComponent<Text>();
        //通信結果をLogで出す
        if (www.error != null)
        {
            //エラー内容 -> www.error
            Debug.Log(www.error);
            posttext.text = "エラー"+www.error.ToString();
        }
        else
        {
            //通信結果 -> www.text
            Debug.Log(www.text);
            posttext.text = "イケル"+www.text.ToString();
            DataControl.dataInsert(www.text);
            DataTable dt = DataControl.getData();
            foreach(DataRow dr in dt.Rows)
            {
                Debug.Log(dr.Count);
            }
        }
    }
}