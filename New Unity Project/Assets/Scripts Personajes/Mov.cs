using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour {
    public float speed = 10.0f;
    public float rotationSpeed = 180.0f;
    public float inputMovement = 0.0f;
    public float inputRotation = 0.0f;
    Rigidbody rigid;
    Animator anim;
    bool mov;
    bool dan;
    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        inputMovement = Input.GetAxis("Vertical");
        inputRotation = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
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
            Vector3 pos = new Vector3(192f, 0.30f, 192.83f);
            transform.position = pos;
        }
        if (collision.gameObject.name == "Portal 1")
        {
            Vector3 pos = new Vector3(10f, 0.30f, 193.83f);
            transform.position = pos;
        }
        if (collision.gameObject.name == "Portal 2")
        {
            Vector3 pos = new Vector3(193f, 0.30f, 14f);
            transform.position = pos;
        }
        if (collision.gameObject.name == "Portal 3")
        {
            Vector3 pos = new Vector3(-10f, 0.30f, -193f);
            transform.position = pos;
        }
        if (collision.gameObject.name == "Portal 4")
        {
            Vector3 pos = new Vector3(-193f, 0.30f, 2f);
            transform.position = pos;
        }

    }
}
