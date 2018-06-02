using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTriggerEnter : MonoBehaviour {
    public int index;
    private int Count=0;
	// Use this for initialization
    private GameManager instance;
    private float time = 2f;//无敌时间
    void Awake()
    {
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(time>=0)
        {
            time -= Time.deltaTime;
        }
        
        
	}

    void CrashOnWallOrOtherPlayer()
    {
        if (transform.parent.GetComponent<SnakeController>())
        {
            _Data.isGameOver = true;
            Debug.Log("死了");
        }
        else if (transform.parent.GetComponent<AISnakeController>())
        {
            transform.parent.GetComponent<AISnakeController>().isDie = true;
            Debug.Log("AI死亡");
        }
        instance.DeleteSnakeBody(gameObject.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case _Data.obs:
                CrashOnWallOrOtherPlayer();
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
            case "body":
                if(time<0)
                {
                    string otherParentName = other.transform.parent.name;

                    if (this.gameObject.transform.parent.name == "SnakeBlue" && otherParentName == "body")
                    {
                        //就是玩家与自身碰撞 这个不要紧
                    }
                    else
                    {

                        string AIbodyindex = otherParentName.Substring(otherParentName.Length - 2, 1);//AI身体的编号
                        string AIHeadName = gameObject.transform.parent.name;
                        string AIHeadindex = AIHeadName.Substring(AIHeadName.Length - 1, 1);//AI头的编号
                        if (AIbodyindex != AIHeadindex)
                        {
                            CrashOnWallOrOtherPlayer();
                        }
                    }
                }
                break;
            default:
                break;
        }
        
    }
}
