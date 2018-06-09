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
    public Image photoPicture;
    public Image reviewStars;
    public Image myReviewStars;
    public Text myComment;
    public Text tagView;

    public Text phoneNumber;
    public Text postCode;

	// Use this for initialization
	void Start () {
        shopName = GameObject.Find("shopName").GetComponent<Text>();

        // データを条件指定して1件取得
        DataRow drone = DataControl.getOneData("id=" + SceneUtility.photoid.ToString());

        var imagePath = drone["image_path"];

        if(imagePath != null)
        {
            CaptureView captureView = new CaptureView();
            photoPicture.sprite = captureView.GetSprite(drone["image_path"].ToString());

        }


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

        string tags = "";

        for(int i = 1; i < 6; i++)
        {
            if (drone[("tag" + i.ToString())] == null) continue;
            string str = (drone[("tag" + i.ToString())].ToString());
            if (str != null) {
                Debug.Log(str);
                if (i != 1) str = "," + str;
                tags = tags + str;
            }
            else
            {
                break;
            }
        }

        tagView.text = "tag:" + tags;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
