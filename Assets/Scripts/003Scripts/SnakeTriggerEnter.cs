using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTriggerEnter : MonoBehaviour {
    public int index;
    private int Count=0;
	// Use this for initialization
    private GameManager instance;
    void Awake()
    {
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case _Data.obs:
                Debug.Log("死了");
                _Data.isGameOver = true;
                
                break;
            case _Data._Food:
                Destroy(other.gameObject);
                GameObject temp=null;
                if(transform.parent.GetComponent<SnakeController>())
                {
                    temp = transform.parent.GetComponent<SnakeController>().body;
                }
                else if (transform.parent.GetComponent<AISnakeController>())
                {
                    temp = transform.parent.GetComponent<AISnakeController>().Body;
                }
                else
                {
                    Debug.Log("异常");
                }
                instance.AddSnakeBody(index,Count,temp);
                Count++;
                break;
            default:
                break;
        }
        
    }
}
