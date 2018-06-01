using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photoDetailController : MonoBehaviour {

    public GameObject reviewPanel;
    public Text shopName;
    public Text reviewNumber;
    //public InputField reviewCommand;
    public Image reviewStars;
    public Image myReviewStars;

	// Use this for initialization
	void Start () {
        shopName = GameObject.Find("shopName").GetComponent<Text>();

        // データを条件指定して1件取得
        DataRow drone = DataControl.getOneData("id=" + SceneUtility.photoid.ToString());
        Debug.Log(drone["name"]);
        shopName.text = drone["name"].ToString();

        string rate = drone["myrating"].ToString();

        if (rate == null) {
            rate = drone["rating"].ToString();
        }

        float tempReviewNum = float.Parse(rate) / 5.0f;

        reviewStars.fillAmount =  tempReviewNum;
        myReviewStars.fillAmount = tempReviewNum;

        reviewNumber.text = rate;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
