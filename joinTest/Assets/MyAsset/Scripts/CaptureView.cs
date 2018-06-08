using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CaptureView : MonoBehaviour
{
    byte[] texture;
    Texture tex;        //textureをTexture型にするための変数

    /// <summary>
    /// オブジェクトに画像をテクスチャにして張り付ける
    /// 貼り付ける画像は日付参照なのでとりあえず撮影→表示としかできない(一覧画面から直接飛ぶには改良が必要)
    /// DBの情報も紐づけてないのでそこも必要・・・
    /// 画像表示用の板オブジェクトを作ってそこにアタッチする
    /// </summary>

    void Start()
    {
        
        //時間を取得してその時間の画像ファイルをbyte[]型変数に格納
        string date = DateTime.Now.ToString("yyyyMMddhhmm");
        texture = readPngFile(Application.persistentDataPath + "/photo"+"/"+date+".jpg");

        //textureをTexture型に変換
        tex = readByBinary(texture);

        //texをアタッチしたオブジェクトのテクスチャにする
        Renderer renderer = this.GetComponent<Renderer>();
        renderer.material.mainTexture = tex;
        
    }

    public Sprite GetSprite(string path)
    {
        texture = readPngFile(path);
 
        Texture2D texture2d = new Texture2D(0, 0);
        texture2d.LoadImage(texture);
        return Sprite.Create(texture2d, new Rect(0, 0, Screen.width, Screen.height), Vector2.zero);
        ;
    }

    /// <summary>
    /// 画像を開いてbyte[]型配列に格納
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public byte[] readPngFile(string path)
    {
        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            BinaryReader bin = new BinaryReader(fileStream);
            byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);
            bin.Close();
            return values;
        }
    }

    /// <summary>
    /// byte[]をTexture型に変換
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public Texture readByBinary(byte[] bytes)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }

}
