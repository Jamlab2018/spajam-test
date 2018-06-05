using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photoDetailController : MonoBehaviour {

    public GameObject reviewPanel;
    public GameObject myCommentView;

    public Text shopName;
    public Text reviewNumber;
    //public InputField reviewCommand;
    public Image reviewStars;
    public Image myReviewStars;
    public Text myComment;

    public Text phoneNumber;
    public Text postCode;

	// Use this for initialization
	void Start () {
        shopName = GameObject.Find("shopName").GetComponent<Text>();

        // データを条件指定して1件取得
        DataRow drone = DataControl.getOneData("id=" + SceneUtility.photoid.ToString());
        
        //店舗名の更新
        shopName.text = drone["name"].ToString();

        //レビュー表記の更新
        string rate = drone["myrating"].ToString();
        if (rate == "") {
            rate = drone["rating"].ToString();
        }
        //星の画像を調整するための値を取得
        float tempReviewNum = float.Parse(rate) / 5.0f;
        reviewStars.fillAmount =  tempReviewNum;
        myReviewStars.fillAmount = tempReviewNum;
        reviewNumber.text = rate;

        //使用者がコメントした内容を表示
        myComment.text = drone["mycomment"].ToString();

        if (myComment.text == "") myCommentView.SetActive(false);

        phoneNumber.text = "電話番号：" + drone["phone_number"].ToString();
        postCode.text = "所在地：" + drone["address"].ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
