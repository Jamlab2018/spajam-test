using UnityEngine;

using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ScrollController : MonoBehaviour
{
    const int NORMAL_MODE = 0;
    const int DELETE_MODE = 1;

    [SerializeField]
    GameObject scrollView;
    ScrollRect scrollRect;

    [SerializeField]
    RectTransform prefab = null;

    [SerializeField]
    GameObject menuList;

    GameObject photoDetailPanel;
    GameObject photoButton;
    GameObject deleteButton;
    GameObject cancelButton;

    List<listViewNode> listViewNodes;

    //ビューのモード
    int mode;

    void Start()

    {
        //初期化
        mode = NORMAL_MODE;
        listViewNodes = new List<listViewNode>();
        photoButton = GameObject.Find("photoButton");
        deleteButton = GameObject.Find("deleteButton");
        cancelButton = GameObject.Find("cancelButton");
        cancelButton.SetActive(false);

        //スクロールビューを展開後にデータベースの問い合わせを行う。
        //完了次第、リストの作成を行う予定。

        //データベースから取得した個数に応じて、リストを作成する予定。
        for (int i = 0; i < 15; i++)

        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);

            listViewNode node = item.gameObject.GetComponent<listViewNode>();
            node.setOwner(this);

            //詳細情報をノードに設定する
            photoDetailInfo info = new photoDetailInfo();
            info.photoID = i;
            node.setDetailInfo(info);

            listViewNodes.Add(node);

            //データベースから取得した情報を、各カラムに保存する。
            //画像エリアの取得
            Image childImageName = item.gameObject.transform.Find("Image").gameObject.GetComponent<Image>();
            childImageName.sprite = Resources.Load<Sprite>("Icon"); 

            //お店の名前の取得
            Text childTitleName = item.gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
            childTitleName.text = "HelloWorld!!";

            //お店名の取得

            //評価内容

            //評価の星

            //お店の画像とお店の名前と評価の星と評価のコメント
            /*
            var text = item.GetComponentInChildren<Text>();

            text.text = "item:" + i.ToString();
            */
        }

        //スクロールビューの頭から表示されるように
        scrollRect = scrollView.GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = 1;

        //ここは別シーンにて作成を行う。
        /*
        photoDetailPanel = GameObject.FindGameObjectWithTag("photoDetailPanel");
        photoDetailPanel.SetActive(false);
        */
    }


    public void launchPhotoMode()
    {
        //SceneUtility.moveScene();
        //カメラモードへ遷移を行う。
    }



    //削除モードへの遷移。（メニューボタンをタップしたときに起動。）
    public void changeDeleteMode()
    {
        this.mode = DELETE_MODE;
        photoButton.SetActive(false);
        cancelButton.SetActive(true);
        menuList.SetActive(false);
    }

    public void cancelDeleteMode()
    {
        this.mode = NORMAL_MODE;
        photoButton.SetActive(true);
        cancelButton.SetActive(false);
    }

    //データのデリート処理を行う
    public void executeDeleteData()
    {
        bool checkflg = false;

        for(int i = 0; i < listViewNodes.Count; i++)
        {

            //デリーとフラグが立っていればデータベースの削除
            if (listViewNodes[i].getDeleteFlg())
            {
                checkflg = true;

                //Todo:データベースの削除

                //リストの削除
                listViewNodes.RemoveAt(i);
            }
        }

        //データベース内のデータを削除した場合は再読み込みを行う。
        if (!checkflg)
        {
            //Todo:データベースの削除
        }

        //終了処理
        photoButton.SetActive(true);
        cancelButton.SetActive(false);
        this.mode = NORMAL_MODE;

    }

    //メニューを表示させる
    public void popupMenu()
    {
        /*
        // プレハブを取得
        menuList = (GameObject)Resources.Load("Prefabs/AlubummenuPanel");
        // プレハブからインスタンスを生成
        Instantiate(menuList, prefab.position, Quaternion.identity);
        */
        //GameObject menuPanel = GameObject.Find("AlubummenuPanel");
        menuList.SetActive(!menuList.active);


    }

    public void touchNode(listViewNode node) {

        //モードに応じて、処理を分ける。

        //ナンバーとその他必要な情報を取得し、その詳細画面を表示させる。
        //移動関数(node.getDetailinfo);
        switch (this.mode) {
            case NORMAL_MODE:
                this.openPictureDetailPanel(node.getDetailInfo());
                break;
            case DELETE_MODE:
                node.setDeleteFlg(!node.getDeleteFlg());
                if (node.getDeleteFlg()) { 
                    node.gameObject.GetComponent<Image>().color = new Color(132f / 255f, 68f / 255f, 205f / 255f);
                }
                else
                {
                    node.gameObject.GetComponent<Image>().color = new Color(227f / 255f, 138f / 255f, 138f / 255f);
                }
                break;
        }
    }

    //リストから詳細画面を開く
    private void openPictureDetailPanel(photoDetailInfo info) 
    {
        SceneUtility.moveScene("photoAlubum","photoDetail",info.photoID);
        //photoDetailPanel.GetComponent<photoDetailPanel>().launchDetailView(info);
        //他シーンに遷移する処理を作成する
    }

}