using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : MonoBehaviour {

   public static string beforeScene;
   public static int photoid;
    public static string query = "";

    //シーンを遷移する。
    public static void moveScene(string beforeScene, string afterScene,int photoid)
    {
        SceneUtility.beforeScene = beforeScene;
        SceneManager.LoadScene(afterScene);
        SceneUtility.photoid = photoid;
    }

    //シーンを戻る
    public void backScene()
    {
        SceneManager.LoadScene(SceneUtility.beforeScene);
    }

    public void setQuery(string query)
    {
        SceneUtility.query = query;
    }
}
