using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {

    public GameObject[] mHelp;
    private GameObject backbtn;
    public GameObject SkinPart;
    int index = 0;
	// Use this for initialization

    public void LeftClick()
    {
        if(index>0)
            index--;
        HidePicture();
    }
    public void RightClick()
    {
        if (index < mHelp.Length-1)
            index++;
        HidePicture();
    }
    public void RuleClick()
    {
        gameObject.SetActive(true);
    }

    public void BackClick()
    {
        gameObject.SetActive(false);
        
    }

    public void SkinBackClick()
    {
        SkinPart.SetActive(false);
    }

    public void ToSkinClick()
    {
        SkinPart.SetActive(true);
    }

    public void GameOver()
    {
        Application.Quit();
    }
  

    void HidePicture()
    {
        switch (index)
        {
            case 0:
                mHelp[0].SetActive(true);
                mHelp[1].SetActive(false);
                mHelp[2].SetActive(false);
                break;
            case 1:
                mHelp[0].SetActive(false);
                mHelp[1].SetActive(true);
                mHelp[2].SetActive(false);
                break;
            case 2:
                mHelp[0].SetActive(false);
                mHelp[1].SetActive(false);
                mHelp[2].SetActive(true);
                break;
            default:
                break;
        }
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
