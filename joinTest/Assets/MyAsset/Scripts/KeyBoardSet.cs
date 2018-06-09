using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NotScreenResizeAndroidSetting();

    }


    /// <summary>

    /// Androidで通知バー表示設定時にソフトキーボード表示で画面サイズを変更しないようにする

    /// </summary>

    void NotScreenResizeAndroidSetting()

    {

#if UNITY_ANDROID

        if (Application.platform != RuntimePlatform.Android)
        {

            return;

        }

        AndroidJNI.AttachCurrentThread();

        AndroidJNI.PushLocalFrame(0);

        try
        {

            // Activityを取得

            using (AndroidJavaClass jcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))

            using (AndroidJavaObject joActivity = jcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {

                // UIスレッドで実行する

                joActivity.Call("runOnUiThread", new AndroidJavaRunnable(RunOnUiThread));

            }

        }
        catch (System.Exception ex)
        {

            Debug.LogError(ex.Message);

        }
        finally
        {

            AndroidJNI.PopLocalFrame(System.IntPtr.Zero);

        }

#endif

    }



    /// <summary>

    /// UIスレッドで実行する

    /// </summary>

    void RunOnUiThread()

    {

#if UNITY_ANDROID

        // AndroidのActivity上で以下のコードを呼び出す

        // getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_NOTHING);

        using (AndroidJavaClass jcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))

        using (AndroidJavaObject joActivity = jcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))

        using (AndroidJavaObject joWindow = joActivity.Call<AndroidJavaObject>("getWindow"))
        {

            joWindow.Call("setSoftInputMode", 48);

        }

#endif

    }
}
