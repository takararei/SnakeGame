using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {

    public void LoadScene002()
    {
        _Data.ResetData();
        SceneManager.LoadScene("Test002");
    }

    public void LoadScene003()
    {
        _Data.ResetData();
        SceneManager.LoadScene("Test003");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
