using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public int cantidad;
    GameObject start;
    public Vector3 pos;
    public bool ganar;


	// Use this for initialization
	void Start () {
        start = GameObject.Find("Start");
        ganar = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (cantidad == 0)
        {
            pos = new Vector3(192, 0.3f, 192);
            start.transform.position = pos;
        }
        if (cantidad == 1)
        {
            pos = new Vector3(-192, 0.3f, 192);
            start.transform.position = pos;
        }
        if (cantidad == 2)
        {
            pos = new Vector3(-192, 0.3f, -192);
            start.transform.position = pos;
        }
        if (cantidad == 3)
        {
            pos = new Vector3(192, 0.3f, -192);
            start.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.N))
        {
            ganar = false;
            cantidad = 0;
        }
    }
}
