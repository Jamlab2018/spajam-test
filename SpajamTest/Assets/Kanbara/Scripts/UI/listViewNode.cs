using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listViewNode : MonoBehaviour {

    ScrollController owner;
    shopDetailInfo info;

    //public DetailPictInfo info;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //オーナーをセットする
    public void setOwner(ScrollController scController)
    {
        this.owner = scController;
    }

    //お店の情報をセットする。
    public void setDetailInfo(shopDetailInfo info)
    {
        this.info = info;
        //各種情報をセットする。
        //info.Shopid = 10;
    }

    //お店の詳細情報を取得する

    public shopDetailInfo getDetailInfo()
    {
        return this.info;
    }

    public void touchNode()
    {
        Debug.Log(info.Shopid);
        owner.touchNode(this);
    }
}
