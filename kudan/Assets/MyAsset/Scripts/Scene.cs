using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {
    public static bool noshot;
	// Use this for initialization
	void Start () {
        //写真撮ったあとはボタン押せないように
        noshot = true;
	}
	
	// Update is called once per frame
	public void OnClick () {
        if (noshot == true)
        {
            SceneManager.LoadScene("Album");
        }
	}
}
