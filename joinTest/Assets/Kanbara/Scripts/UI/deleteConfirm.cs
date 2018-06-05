using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteConfirm : MonoBehaviour {

    ArrayList deleteDataArray;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="array"></param>
    public void initializeDialog(ArrayList array)
    {
        deleteDataArray = array;
    }


    ///
    public void pushDecideButton()
    {
        //データベースの削除を行う。

        this.gameObject.SetActive(false);
    }

    public void pushCancelButton()
    {
        this.gameObject.SetActive(false);
    }


}
