using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {
    
	void Start () {
        // エディタで更新、挿入した場合はいかに保存される
        // C: \Users\[ユーザー名]\AppData\LocalLow\[player SettingのCompanyName]\
        DataBaseControle.jsonInsert(2, "ざ・ろっく");
        //DataBaseControle.jsonSelect(2);
	}
	
	void Update () {
		
	}
}
