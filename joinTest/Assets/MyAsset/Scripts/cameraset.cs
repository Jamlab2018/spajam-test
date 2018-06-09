using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class cameraset : MonoBehaviour
{
    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 30;
    public static bool create;

    public GameObject back;
    public GameObject shot;
    public GameObject Prog;
    bool once = true;
    Transform progtransform;
    float time = 0;
    bool progress;                  //プログレスダイアログ表示
    WebCamTexture webcamTexture;
    public Material material;
    GameObject place;
    void Start()
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.Hidden;
        Prog.SetActive(false);
        once = true;
        progress = false;
        create = false;
        time = 0;
        progtransform = Prog.transform;
        WebCamDevice[] devices = WebCamTexture.devices;
        // display all cameras
        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }
        webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);
        material.mainTexture = webcamTexture;
        webcamTexture.Play();
        if (!Directory.Exists("Application.persistentDataPath"+"/photo"))
        {
            // フォルダが存在しないなら作成
            Directory.CreateDirectory(Application.persistentDataPath+"/photo");

        }
    }
    private void Update()
    {
        if (progress == true)
        {
            Prog.SetActive(true);
            time = 360 * Time.deltaTime;

            progtransform.Rotate(new Vector3(0.0f, 0.0f, -time));

        }
    }
    public void OnCapture()
    {
        if (once == true)
        {
            once = false;//画面遷移するまでtrueにならない
            back.SetActive(false);
            shot.SetActive(false);
            string date = DateTime.Now.ToString("yyyyMMddHHmm");
            StartCoroutine(
             cameraset.Capture(
                    imageName: "photo/" + date + ".jpg",
                    callback: Callback
                )
            );
        }
    }

    private void Callback()
    {
        string date = DateTime.Now.ToString("yyyyMMddHHmm");
        string imageName = "photo/" + date + ".jpg";
        string imagePath = Path.Combine(Application.persistentDataPath, imageName);
        if (File.Exists(imagePath))
        {
            progress = true;
            create = true;
            Debug.Log("撮影完了");
        }

        if (create == false)
        {
            once = true;//もう一度撮影できるように
            progress = false;
            Prog.SetActive(false);
            shot.SetActive(true);
            back.SetActive(true);
        }
        // SceneManager.LoadScene("photo");

    }

    /// <summary>

    /// スクリーンショットを撮る

    /// </summary>

    public static IEnumerator Capture(string imageName = "image.jpg", Action callback = null)
        {
            //スクショを保存するパスを作成
            string imagePath = imageName;

        //iOS、Android実機の時はパスにApplication.persistentDataPathを追加
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
        imagePath = Path.Combine(Application.persistentDataPath, imageName);
#else
        string date1 = DateTime.Now.ToString("yyyyMMddhhmm");
        imagePath = "C:/Users/spajam/Documents/kudan/Assets/MyAsset/photo"+date1+"jpg";
#endif

        //前に撮ったスクショを削除
        File.Delete(imagePath);

            //スクリーンショットを撮る
            ScreenCapture.CaptureScreenshot(imageName);

            //スクリーンショットが保存されるまで待機(最大2秒)
            float latency = 0, latencyLimit = 2;

            while (latency < latencyLimit)
            {

                //ファイルが存在していればループ終了
                if (File.Exists(imagePath))
                {
                    break;
                }
                latency += Time.deltaTime;
                yield return null;
            }



            //待機時間が上限に達していたら警告表示(おそらくスクショが保存出来ていない時)

            if (latency >= latencyLimit)
            {
            }



            //コールバックが登録されていれば実行

            if (callback != null)
            {

                callback();

            }
     }
}
 