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
    public void CreateSnake(string str,GameObject SnakeBlue,GameObject Body)
    {
        GameObject head = Instantiate(SnakeHead[CheckSkin(str)]);
        head.transform.SetParent(SnakeBlue.transform);
        head.transform.localPosition = Vector3.zero;
        head.transform.localScale = Vector3.one;
        GameObject body;
        for(int i=0;i<_Data.SnakeLength;i++)
        {
            if(i%3==0&&i!=0)
            {
                body = Instantiate(SnakeBody[CheckSkin(str)]);
            }
            else
            {
                body = Instantiate(SnakeEmpty);
            }
            body.transform.SetParent(Body.transform);
            body.transform.position = new Vector3(head.transform.position.x - (i + 1) * 12, head.transform.position.y, 0);
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
        _Data.MySnakeLength++;
        //temp.transform.parent = Body.transform;
        temp.transform.SetParent(Body.transform);
        temp.transform.localScale = Vector3.one;
    }
}
