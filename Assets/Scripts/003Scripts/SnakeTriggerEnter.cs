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
        }
        else if (transform.parent.GetComponent<AISnakeController>())
        {
            transform.parent.GetComponent<AISnakeController>().isDie = true;
            
        }
        instance.DeleteSnakeBody(gameObject.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (transform.parent.GetComponent<SnakeController>()&&_Data.isGameOver)
        {
            return;
        }
        else if (transform.parent.GetComponent<AISnakeController>()&& transform.parent.GetComponent<AISnakeController>().isDie)
        {
            return;
        }
        switch (other.tag)
        {
            case _Data.obs:
                CrashOnWallOrOtherPlayer();
                //Debug.Log("AI撞壁" + transform.parent.name);
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
            case "body"://蛇头与身体相撞
                if(time<0)
                {
                    string otherParentName = other.transform.parent.name;
                    if (!(this.gameObject.transform.parent.name == "SnakeBlue" && otherParentName == "body"))
                    {

                        string AIbodyindex = otherParentName.Substring(otherParentName.Length - 2, 1);//AI身体的编号
                        string AIHeadName = gameObject.transform.parent.name;
                        string AIHeadindex = AIHeadName.Substring(AIHeadName.Length - 1, 1);//AI头的编号
                        if (AIbodyindex != AIHeadindex)
                        {
                            //CrashOnWallOrOtherPlayer();
                            if (transform.parent.GetComponent<SnakeController>())
                            {
                                _Data.isGameOver = true;
                            }
                            else if (transform.parent.GetComponent<AISnakeController>())
                            {
                                transform.parent.GetComponent<AISnakeController>().isDie = true;
                                if(other.transform.parent.name=="body")
                                {
                                    _Data.MySnakeKill++;
                                }
                            }
                            instance.DeleteSnakeBody(gameObject.transform);
                            //Debug.Log("AI撞AI" + transform.parent.name+","+other.transform.parent.name);
                        }
                    }
                }
                break;
            default:
                break;
        }
        
    }
}
