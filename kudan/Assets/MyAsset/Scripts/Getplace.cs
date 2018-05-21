﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Getplace : MonoBehaviour {
    public GameObject text ;
    Text placetext;
    float gps_x;    //位置情報x
    float gps_y;    //位置情報y
    //写真ボタンを押したら位置情報を取得する。
    GameObject post;
    public void placeclick()
    {
        StartCoroutine(
         Getplace.place(
             callback: Callback
             )
         );
        
    }
    void Callback()
    {
        //取得した情報表示
        //これを画像と一緒に投げる

        placetext = text.GetComponent<Text>();
        placetext.text = "Location: " +
                  "\n緯度gps_x " + Input.location.lastData.latitude +
                  "\n経度gps_y " + Input.location.lastData.longitude +
                  "\n標高 " + Input.location.lastData.altitude +
                  "\n水平精度 " + Input.location.lastData.horizontalAccuracy +
                  "\n垂直精度 " + Input.location.lastData.verticalAccuracy +
                  "\nタイムスタンプ " + Input.location.lastData.timestamp;
        gps_x = Input.location.lastData.latitude;
        gps_y = Input.location.lastData.longitude;

        post = GameObject.Find("Post");
        HttpRequestManager p1 = post.GetComponent<HttpRequestManager>();
        p1.Post(gps_x, gps_y);

    }
    public static IEnumerator place(Action callback = null)
    {
        if (!Input.location.isEnabledByUser)
        {

           yield break;
        }
        Input.location.Start();
        int maxWait = 120;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            print("Location: " +
            Input.location.lastData.latitude + " " +
            Input.location.lastData.longitude + " " +
            Input.location.lastData.altitude + " " +
            Input.location.lastData.horizontalAccuracy + " " +
            Input.location.lastData.timestamp);
        }
        //コールバックが登録されていれば実行

        if (callback != null)
        {

            callback();

        }

        Input.location.Stop();
    }

}