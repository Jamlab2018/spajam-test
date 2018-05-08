using UnityEngine;

using System.Collections;

using UnityEngine.UI;



public class ScrollController : MonoBehaviour
{



    [SerializeField]
    GameObject scrollView;
    ScrollRect scrollRect;

    [SerializeField]
    RectTransform prefab = null;

    GameObject photoDetailPanel;

    void Start()

    {


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
            shopDetailInfo info = new shopDetailInfo();
            info.Shopid = i;
            node.setDetailInfo(info);
            

            //データベースから取得した情報を、各カラムに保存する。
            //画像エリアの取得
            Image childImageName = item.gameObject.transform.Find("Image").gameObject.GetComponent<Image>();
            childImageName.sprite = Resources.Load<Sprite>("Icon"); 

            //お店の名前の取得
            Text childTitleName = item.gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
            childTitleName.text = "こんにてゃ";

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

        //
        photoDetailPanel = GameObject.FindGameObjectWithTag("photoDetailPanel");
        photoDetailPanel.SetActive(false);
    }

    public void touchNode(listViewNode node){
        //ナンバーとその他必要な情報を取得し、その詳細画面を表示させる。
        //移動関数(node.getDetailinfo);
        this.openPictureDetailPanel(node.getDetailInfo());
    }

    //リストから詳細画面を開く
    private void openPictureDetailPanel(shopDetailInfo info) 
    {
        photoDetailPanel.SetActive(true);
    }

}