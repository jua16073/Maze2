using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mov : NetworkBehaviour {
    public float speed = 10.0f;
    public float rotationSpeed = 180.0f;
    public float inputMovement = 0.0f;
    public float inputRotation = 0.0f;
    Rigidbody rigid;
    Animator anim;
    bool mov;
    bool dan;
    Controller cantidad;
    int num;
    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cantidad = GameObject.Find("Controller").GetComponent<Controller>();
        num = cantidad.cantidad;
        cantidad.cantidad++;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        inputMovement = Input.GetAxis("Vertical");
        inputRotation = Input.GetAxis("Horizontal");
        if (num== cantidad.cantidad)
        {
           transform.position = cantidad.pos;
            cantidad.cantidad++;
        }
    }
    private void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        Vector3 desplazamiento = transform.forward * inputMovement * speed * Time.deltaTime;
        //transform.Translate(desplazamiento);
        rigid.MovePosition(rigid.position + desplazamiento);
        float turn = inputRotation * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, turn, 0.0f);
        //transform.rotation(transform.rotation * turnRotation);
        rigid.MoveRotation(transform.rotation * turnRotation);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            mov = true;
        }
        else
            mov = false;
        anim.SetBool("Mov", mov);
        if (Input.GetKey(KeyCode.C))
        {
            dan = true;
        }
        else
            dan = false;
        anim.SetBool("Baile", dan);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name== "Wall")
        {
            rigid.velocity = Vector3.zero;
        }
        if (collision.gameObject.name== "key_gold")
        {
            Vector3 pos = new Vector3(240f, 100f, 0f);
            transform.position = pos;
            cantidad.ganar = true;
        }
        if (collision.gameObject.name == "Portal 1")
        {
            Vector3 pos = new Vector3(-91.7f, 0.30f, 29.2f);
            transform.position = pos;
        }
        if (collision.gameObject.name == "Portal 2")
        {
            Vector3 pos = new Vector3(11.5f, 0.30f, -71.1f);
            transform.position = pos;
        }
        if (collision.gameObject.name == "Portal 3")
        {
            Vector3 pos = new Vector3(95.5f, 0.30f, -8.4f);
            transform.position = pos;
        }
        if (collision.gameObject.name == "Portal 4")
        {
            Vector3 pos = new Vector3(-9.9f, 0.30f, -71.1f);
            transform.position = pos;
        }

    }
}
