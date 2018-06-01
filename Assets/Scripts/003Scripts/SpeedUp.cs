using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Walk()
    {
        _Data.isSpeedUp = false;
    }

    public void Run()
    {
        _Data.isSpeedUp = true;
    }
}
