using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OnCreate : NetworkBehaviour {
    public Camera camara;
	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            camara = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
            camara.transform.parent = this.transform;
            Vector3 pos = new Vector3(0, 25, -15);
            var rotation = transform.rotation.eulerAngles;
            rotation.x = 30;
            camara.transform.localPosition = pos;
            camara.transform.localRotation= Quaternion.Euler(rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
}
