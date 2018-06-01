using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public Text SnakeLength;
    public Text SnakeKill;
    public Text DieSnakeLength;
    public Text DieSnakeKill;
    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        SnakeLength.text = "蛇的长度："+_Data.MySnakeLength.ToString();
        DieSnakeLength.text = "蛇的长度：" + _Data.MySnakeLength.ToString();
	}
}
