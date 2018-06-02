using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIintelligence : MonoBehaviour {

    private AISnakeController instance;
	// Use this for initialization
	void Start () {
        instance = transform.parent.GetComponent<AISnakeController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case _Data.obs:
                instance.ForwardObs();
                break;
            case _Data._Head:
                //if(other.transform.parent.name)
                //Debug.Log(other.name);
                if(other.transform.parent.name!=transform.parent.name)
                instance.ForwardObs();
                break;

            case _Data._Food:
                break;
            default:
                break;
        }

    }
}
