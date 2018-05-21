using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Sample : MonoBehaviour {
	
    public void TEST()
    {


        // データを全て取得
        DataTable dt = DataControl.getData();
        foreach (DataRow dr in dt.Rows)
        {
            Debug.Log(dr["name"]);
        }

        // データを条件指定して取得
        DataTable dtw = DataControl.getData("id=1");
        foreach (DataRow dr in dtw.Rows)
        {
            Debug.Log(dr["name"]);
        }

        // データを条件指定して1件取得
        DataRow drone = DataControl.getOneData("id=1");
        Debug.Log(drone["name"]);
        

    }
    
}
