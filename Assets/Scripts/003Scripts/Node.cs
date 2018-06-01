using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    private Vector3 startPoint, EndPoint;
    public GameObject[] nodes;
    public int NodeCount;
    void Awake()
    {
        startPoint = new Vector3(2500,1300,0);
        EndPoint = new Vector3(-2500, -1300, 0);

    }
    
    private void CreateNode()
    {
        for (int i = 0; i < NodeCount;i++ )
        {
            GameObject temp = Instantiate(nodes[Random.Range(0,nodes.Length)]);
            Vector3 v = new Vector3(Random.Range(startPoint.x, EndPoint.x),
                Random.Range(startPoint.y, EndPoint.y), 0);
            //temp.transform.parent = transform;
            temp.transform.SetParent(transform);
            temp.transform.position = v;
        }
    }
	// Use this for initialization
	void Start () {
        CreateNode();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
