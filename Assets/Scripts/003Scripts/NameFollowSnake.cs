using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameFollowSnake : MonoBehaviour {
    public Transform SnakeHead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 temp = SnakeHead.localPosition;
        temp.y += 45f;
        temp.x += 48f;
        transform.position = Vector3.Lerp(transform.position,temp,1f);
	}
}
