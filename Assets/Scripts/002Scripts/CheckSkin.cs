using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckSkin : MonoBehaviour {


    private Button skinbtn;
    private Text selectSkin;
	// Use this for initialization
	void Start () {
        selectSkin = GameObject.Find("SelectSkin").GetComponent<Text>();
        skinbtn = gameObject.GetComponent<Button>();
        skinbtn.onClick.AddListener(SkinBtnClick);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SkinBtnClick()
    {
        selectSkin.text = gameObject.GetComponent<Image>().sprite.name;
        _Data.SkinName = selectSkin.text;
    }
}
