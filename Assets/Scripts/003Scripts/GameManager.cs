using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] SnakeHead;
    public GameObject[] SnakeBody;
    public GameObject SnakeBlue;
    //public GameObject Body;
    public GameObject SnakeEmpty;
    public string[] AISkin = new string[] { "小篮", "亲色", "小绿", "紫红", "大红", "小黄" };
    public GameObject[] SnakeAI;
    public GameObject Nodes;
    public void CreateSnake(string str,GameObject SnakeBlue,GameObject Body)
    {
        GameObject head = Instantiate(SnakeHead[CheckSkin(str)]);
        head.transform.SetParent(SnakeBlue.transform);
        head.transform.localPosition = Vector3.zero;
        head.transform.localScale = Vector3.one;
        GameObject body;
        for(int i=0;i<_Data.SnakeLength;i++)
        {
           
            if (i % 3 == 0 && i != 0)
            {
                body = Instantiate(SnakeBody[CheckSkin(str)]);
            }
            else
            {
                body = Instantiate(SnakeEmpty);
            }
            body.transform.SetParent(Body.transform);
            body.transform.position = new Vector3(head.transform.position.x - (i + 1) * 12, head.transform.position.y, 0);
            body.transform.localScale = Vector3.one;
        }
        
    }
    public int  CheckSkin(string str)
    {
        
        int temp = 0;
        switch(str)
        {
            case "亲色":
                temp = 1;
                break;
            case "大红":
                temp = 4;
                break;
            case "小篮":
                temp = 0;
                break;
            case "小绿":
                temp = 2;
                break;
            case "小黄":
                temp = 5;
                break;
            case "紫红":
                temp = 3;
                break;
            default:
                temp = 0;
                break;

        }
        return temp;
    }

    public void AddSnakeBody(int nPly,int count,GameObject Body)
    {
        GameObject temp;
        if(count%3==0)
        {
            temp = Instantiate(SnakeBody[nPly]);
        }
        else
        {
            temp = Instantiate(SnakeEmpty);
        }
        if (Body.name.Substring(0, 1) == "A")
        {
            string t = Body.name.Substring(Body.name.Length - 2, 1);
            int tempindex= int.Parse(t);
            SnakeAI[tempindex - 1].GetComponent<AISnakeController>().AISnakeLength++;
        }
        else
        {
            _Data.MySnakeLength++;
        }
        
        //temp.transform.parent = Body.transform;
        temp.transform.SetParent(Body.transform);
        temp.transform.localScale = Vector3.one;
    }

    //蛇死亡后 身体变成食物
    public void DeleteSnakeBody(Transform Head)
    {
        GameObject _body = null;
        if (Head.parent.GetComponent<SnakeController>())
        {
            _body = Head.parent.GetComponent<SnakeController>().body;
        }
        else if (Head.parent.GetComponent<AISnakeController>())
        {
            _body = Head.parent.GetComponent<AISnakeController>().Body;
            Head.parent.GetComponent<AISnakeController>().AddSnake();
        }
        else
        {
            Debug.Log("异常");
        }
        int childCount = _body.transform.childCount;

        for(int i=0;i<childCount;i++)
        {
            if (_body.transform.GetChild(i).name.Substring(0, 10) == "SnakeEmpty")
            {
                Destroy(_body.transform.GetChild(i).gameObject);
            }
            else
            {
                _body.transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(32.23f * 0.7f, 32.23f * 0.7f);
            }
            //if (i % 3 != 0)
            //{
            //    Debug.Log("空" + _body.transform.GetChild(i).name);
            //    Destroy(_body.transform.GetChild(i).gameObject);
                
            //}
            //else
            //{
            //    Debug.Log("非空" + _body.transform.GetChild(i).name);
            //    _body.transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(32.23f * 0.7f, 32.23f * 0.7f);
                
            //}
        }
        childCount = _body.transform.childCount;
        for (int j = 0; j < childCount;j++ )
        {
            _body.transform.GetChild(0).tag=_Data._Food;
            _body.transform.GetChild(0).SetParent(Nodes.transform);
        }
        Destroy(Head.gameObject);

        //if (Head.parent.GetComponent<AISnakeController>())
        //{
        //    Head.parent.GetComponent<AISnakeController>().AddSnake();
        //}

    }




}
