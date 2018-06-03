using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    private Vector3 startPoint, EndPoint;
    public GameObject[] nodes;
    public int NodeCount;
    private float time = 2f;
    void Awake()
    {
        startPoint = new Vector3(2500,1300,0);
        EndPoint = new Vector3(-2500, -1300, 0);

    }
    
    private void CreateNode(int node)
    {
        for (int i = 0; i < node; i++ )
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
        CreateNode(NodeCount);
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time<0)
        {
            CreateNode(3);
            time = 2f;
        }
        
	}
}
