using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform SnakeHead;
    void LateUpdate()
    {
        Vector3 temp = new Vector3(SnakeHead.position.x,SnakeHead.position.y,transform.position.z);

        transform.position=Vector3.Lerp(transform.position,temp,1f);
    }
}
