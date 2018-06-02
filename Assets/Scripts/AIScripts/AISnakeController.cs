using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISnakeController : MonoBehaviour {
    public float Speed=500;
    private Vector3 Direction;
    private GameManager instance;
    public GameObject Body;
    public int AISnakeLength;
    private string AISkin;
    public bool isDie=false;
  
	// Use this for initialization
    void Awake()
    {
        Direction = new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 0f);
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        AISkin = instance.AISkin[Random.Range(0, instance.AISkin.Length)];
    }

	void Start () {
        instance.CreateSnake(AISkin,this.gameObject,Body);	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
		if(isDie)
        {
            return;
        }
        //try
        //{ temp = joystick.JoystickAxis; }
        //catch (Exception e) { return; }

        //if (temp != Vector3.zero)
        //{
        //    MovePoint = temp;
        //}
        transform.position += Direction.normalized * Speed * Time.deltaTime;
        BodyFlootSnakeHead(transform.position);
        if (GetRotation(Direction) != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(GetRotation(Direction));
        }
	}

    private Vector3 GetRotation(Vector3 temp)
    {
        float angle;
        Vector3 v = Vector3.zero;
        angle = 180 * Mathf.Acos(temp.x / Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y)) / Mathf.PI;
        if (Mathf.Acos(temp.x / Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y)) != 0)
        {
            if (angle > 0 && angle <= 90)
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
            else if (angle > 90f && angle <= 180f)
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
        return v;
    }


    void BodyFlootSnakeHead(Vector3 headPoint)
    {
        int bodyCount = Body.transform.childCount;
        Vector3 bodyStartPoint = Vector3.zero;//起始点
        Vector3 bodyEndPoint = Vector3.zero;
        Vector3 lastPoint = Vector3.zero;
        for (int i = 0; i < bodyCount; i++)
        {
            if (i == 0)
            {
                lastPoint = Body.transform.GetChild(i).gameObject.transform.position;
                Body.transform.GetChild(i).gameObject.transform.position = headPoint;
            }
            else
            {
                Vector3 tp = Body.transform.GetChild(i).gameObject.transform.position;
                Body.transform.GetChild(i).gameObject.transform.position = lastPoint;
                lastPoint = tp;
            }

        }
        //for (int i = 0; i < bodyCount; i++)
        //{
        //    GameObject temp = Body.transform.GetChild(i).gameObject;

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
