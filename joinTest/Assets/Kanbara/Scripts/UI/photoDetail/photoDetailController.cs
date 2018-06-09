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
        var name = drone["name"];
        if (name != null) { 
            shopName.text = drone["name"].ToString();
        }
        else
        {
            shopName.text = "";
        }

        float myrating = float.Parse( drone["myrating"].ToString());

        string rate;

        rate = drone["rating"].ToString().ToString();
        Debug.Log(rate); 

        //レビュー表記の更新
        
        if (myrating != 0　&& myrating > 0) {
            rate = drone["myrating"].ToString();
        }
        
      
        //星の画像を調整するための値を取得
        float tempReviewNum = float.Parse(rate) / 5.0f;
        reviewStars.fillAmount =  tempReviewNum;
        myReviewStars.fillAmount = tempReviewNum;
        reviewNumber.text = rate;

        //使用者がコメントした内容を表示
        myComment.text = drone["mycomment"].ToString();

        if (myComment.text == "") myCommentView.SetActive(false);

        if (drone["phone_number"] != null) 
        {
            phoneNumber.text = "電話番号：" + drone["phone_number"].ToString();
        }


        if (drone["address"] != null)
        {
            postCode.text = "所在地：" + drone["address"].ToString();
        }
        

        string tags = "";

        for(int i = 1; i < 6; i++)
        {
            if (drone[("tag" + i.ToString())] == null || drone[("tag" + i.ToString())].ToString() == "") continue;
            string str = (drone[("tag" + i.ToString())].ToString());
            if (str != null) {
                Debug.Log(str);
                if (i != 1) str = "," + str;
                tags = tags + str;
            }
            else
            {
                
            }
        }

        tagView.text = "tag:" + tags;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
