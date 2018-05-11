using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlubumdeleteButton : MonoBehaviour {

    ScrollController scController;


    public void setOwner(ScrollController scController)
    {
        this.scController = scController;
    }
    
    public void executeDeleteData(int deleteid)
    {
        /*DBにアクセスし、指定されたIDを削除する処理を実行*/
        /*DBからのコールバックをスクロールビューで受ける。
         削除中は削除中ビューを生成。*/
    }

    //デリーとしたタイミングで呼ばれる関数。
    public void finishDeleteData()
    {

    }

}
