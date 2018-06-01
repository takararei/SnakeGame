using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakeSkin : MonoBehaviour {
    public Sprite[] Skin;
    public GameObject skin1;
    void Awake()
    {
        int Count = Skin.Length;
        for (int i = 0; i < Count;i++ )
        {
            GameObject temp = Instantiate(skin1) as GameObject;
            //temp.transform.parent = transform;
            temp.transform.SetParent(transform);
            temp.transform.localScale = Vector3.one;
            temp.transform.GetComponent<Image>().sprite = Skin[i];
        }
        Destroy(GetComponent<MakeSkin>());
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
