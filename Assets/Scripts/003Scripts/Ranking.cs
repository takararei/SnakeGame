using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour {
    public static int[] SnakeLength = new int[7];
    public Text[] Name;
    private string[] SnakeName=new string[7];

    private int[] tempLength = new int[7];
    private string[] tempName = new string[7];
	// Use this for initialization
	void Awake () {
        SnakeName[0]= "MySnake";
        SnakeName[1]= "AI1Snake";
        SnakeName[2]= "AI2Snake";
        SnakeName[3]= "AI3Snake";
        SnakeName[4]= "AI4Snake";
        SnakeName[5]= "AI5Snake";
        SnakeName[6]= "AI6Snake";
    }
	
	// Update is called once per frame
	void Update () {

        SnakeLength[0] = _Data.MySnakeLength;
        int snake = 0;
        string name = "";
        for(int i=0;i<tempLength.Length;i++)
        {
            tempLength[i] = SnakeLength[i];
            tempName[i] = SnakeName[i];
        }
       


        for (int i=0;i< tempLength.Length-1;i++)
        {
            for(int j=0;j< tempLength.Length-1;j++)
            {
                if(tempLength[j]< tempLength[j+1])
                {
                    snake = tempLength[j];
                    tempLength[j] = tempLength[j + 1];
                    tempLength[j + 1] = snake;

                    name = tempName[j];
                    tempName[j] = tempName[j + 1];
                    tempName[j + 1] = name;
                }
            }
        }
        for(int i=0;i<Name.Length;i++)
        {
            Name[i].text = tempName[i]+"   :"+ tempLength[i].ToString();
        }
        



    }
}
