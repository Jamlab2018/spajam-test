using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jamReview : MonoBehaviour {

    const int MAX_RATE = 5;

    GameObject reviewView;
    public GameObject stars;//評価の星をまとめたゲームオブジェクト
    public Text comment;

    //星の画像
    Sprite ratingOn;
    Sprite ratingOff;

    public photoDetailController controller;

    int rateNum = 0;



    public void Start()
    {
        reviewView = GameObject.Find("RatePanel");
        
        reviewView.SetActive(false);


        ratingOn = Resources.Load<Sprite>("web_rating_on");
        ratingOff = Resources.Load<Sprite>("user_rating_off");
        //img.material.mainTexture = texture;
    }

    //レビューの画面をポップアップ
    public void popupReview()
    {
        rateNum = 5;

        reviewView.SetActive(true);
        this.changeStars();
    }

    public void pushCancelButton()
    {
        //DBには登録なし
        reviewView.SetActive(false);
    }

    public void pushDecideButton()
    {
        string[] tagPart = comment.text.Split('#');

        string query = "update jtable set myrating =" + rateNum.ToString() + ", mycomment = '" + tagPart[0] + "' where id = " + SceneUtility.photoid.ToString(); 
        DBControll.execute(query);

        float tempRateNum = rateNum / 5.0f;

        //詳細画面の評価も変更する
        controller.reviewStars.fillAmount = tempRateNum;
        controller.reviewNumber.text = rateNum.ToString();

        controller.myReviewStars.fillAmount = tempRateNum;




        controller.myComment.text = tagPart[0];


        //Debug.Log(tagPart[1]);

        if (tagPart.Length != 1)
        {
            string[] tag = tagPart[1].Split(',');
            for (int i = 0; i < tag.Length; i++)
            {
                Debug.Log(tag[i]);
                string tagquery = "update jtable set tag" + (i + 1).ToString() + " = '" + tag[i].ToString() +
                    "' where id = " + SceneUtility.photoid.ToString();
                DBControll.execute(tagquery);
            }
        }

   

        reviewView.SetActive(false);

        if (comment.text != "") controller.myCommentView.SetActive(true);

    }

    //とりあえずの実装
    //レビュー表示の星がタップされたときに呼ばれる関数達
    public void rateOneStar()
    {
        rateNum = 1;
        changeStars();
    }

    public void rateTwoStar()
    {
        rateNum = 2;
        changeStars();
    }


    public void rateThreeStar()
    {
        rateNum = 3;
        changeStars();
    }

    public void rateFourStar()
    {
        rateNum = 4;
        changeStars();
    }

    public void rateFiveStar()
    {
        rateNum = 5;
        changeStars();
    }

    //
    void changeStars()
    {
        for (int i = 0; i < MAX_RATE; i++)
        {
            string str = "Image" + i.ToString();
            Debug.Log(str);
            GameObject childObject = stars.transform.Find(str).gameObject;
            //childObject.GetComponent<Image>().material.mainTexture = starTexture;
            if (i < rateNum) { 
                childObject.GetComponent<Image>().sprite = ratingOn;
            }else{
                childObject.GetComponent<Image>().sprite = ratingOff;
            }
        }
    }


}
