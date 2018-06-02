using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

    public EasyJoystick joystick;
    public float speed;
    public GameManager instance;
    public GameObject body;
    
    Vector3 MovePoint;
    public GameObject Over;
    void Awake()
    {
        MovePoint = new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 0f);
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
	// Use this for initialization
	void Start () 
    {
        _Data.MySnakeLength = _Data.SnakeLength;
        instance.CreateSnake(_Data.SkinName,this.gameObject,body);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if(_Data.isGameOver)
        {
            Over.SetActive(true);
            return;
        }
        Vector3 temp;
        if (_Data.isSpeedUp)
        {
            for (int i = 0; i < 2; i++)
            {
                //try
                //{ 
                    temp = joystick.JoystickAxis; 
                //}
                //catch (Exception e) { return; }

                if (temp != Vector3.zero)
                {
                    MovePoint = temp;
                }
                transform.position += MovePoint.normalized * speed * Time.deltaTime;
                BodyFlootSnakeHead(transform.position);
                if (GetRotation(MovePoint) != Vector3.zero)
                {
                    transform.rotation = Quaternion.Euler(GetRotation(MovePoint));
                }
            }
        }
        else
        {
            //try
            //{
                temp = joystick.JoystickAxis;
            //}
            //catch (Exception e) { return; }

            if (temp != Vector3.zero)
            {
                MovePoint = temp;
            }
            transform.position += MovePoint.normalized * speed * Time.deltaTime;
            BodyFlootSnakeHead(transform.position);
            if (GetRotation(MovePoint) != Vector3.zero)
            {
                transform.rotation = Quaternion.Euler(GetRotation(MovePoint));
            }
        }
        //try
        //{ temp = joystick.JoystickAxis;}
        //catch(Exception e) {return;}

        //if(temp!=Vector3.zero)
        //{
        //    MovePoint = temp;
        //}
        //transform.position += MovePoint.normalized * speed * Time.deltaTime;
        //BodyFlootSnakeHead(transform.position);
        //if (GetRotation(MovePoint) != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.Euler(GetRotation(MovePoint));
        //}
        //Debug.Log(temp);
	}

    private Vector3 GetRotation(Vector3 temp)
    {
        float angle;
        Vector3 v = Vector3.zero;
        //Vector3 v = new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);
        angle = 180 * Mathf.Acos(temp.x / Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y))/Mathf.PI;
        if(Mathf.Acos(temp.x / Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y))!=0)
        {
            if(angle>0&&angle<=90)
            {
                if(temp.y>0)
                {
                    v = new Vector3(0,0,angle+90f);
                }
                else
                {
                    v = new Vector3(0, 0, -angle + 90f);
                }
            }
            else if(angle>90f && angle<=180f)
            {
                if (temp.y > 0)
                {
                    v = new Vector3(0, 0, angle + 90f);
                }
                else
                {
                    v = new Vector3(0, 0, -angle + 90f);
                }
            }
        }
        //if(v==Vector3.zero)
        //{
        //    return Vector3.zero;
        //}
        //else
            return v;
    }


    void BodyFlootSnakeHead(Vector3 headPoint)
    {
        int bodyCount = body.transform.childCount;
        Vector3 bodyStartPoint = Vector3.zero;//起始点
        Vector3 bodyEndPoint = Vector3.zero;
        Vector3 lastPoint = Vector3.zero;
        for (int i = 0; i <bodyCount; i++)
        {
            if (i == 0)
            {
                lastPoint = body.transform.GetChild(i).gameObject.transform.position;
                body.transform.GetChild(i).gameObject.transform.position = headPoint;
            }
            else
            {
                Vector3 tp = body.transform.GetChild(i).gameObject.transform.position;
                body.transform.GetChild(i).gameObject.transform.position = lastPoint;
                lastPoint = tp;
            }

        }
        //for (int i = 0; i < bodyCount; i++)
        //{
        //    GameObject temp = body.transform.GetChild(i).gameObject;

        //    if (i % 2 == 0)
        //    {
        //        bodyStartPoint = temp.transform.position;
        //        if (i == 0)
        //        {
        //            temp.transform.position = headPoint;
        //        }
        //        else
        //        {
        //            temp.transform.position = bodyEndPoint;
        //        }
        //    }
        //    else
        //    {
        //        bodyEndPoint = temp.transform.position;
        //        temp.transform.position = bodyStartPoint;
        //    }
        //}
    }
}
