using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // movement of bowling ball
{
    public float speed = 10.0f;
    private Rigidbody rb;
    public CharacterController controller;
    public float jumpForce;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.GetComponent<Renderer>().material.color = new Color(Globals.ballRed, Globals.ballGreen, Globals.ballBlue);   //ball color
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement * speed);

        rb.velocity = new Vector3(-Input.GetAxis("Horizontal")*speed, rb.velocity.y, -Input.GetAxis("Vertical")*speed);
        if(Input.GetButtonDown("Jump") && canJump){
            rb.velocity = new Vector3(-rb.velocity.x, jumpForce, -rb.velocity.z);
        }
        //GameObject.FindGameObjectWithTag("Ghost").GetComponent<Rigidbody>().velocity = rb.velocity;
        GameObject.FindGameObjectWithTag("Ghost").GetComponent<Rigidbody>().transform.position = new Vector3(transform.position.x + 5.6f, transform.position.y + 3.7f, transform.position.z + 2.6f);
    }
    void OnCollisonEnter(Collider other){
        canJump = true;
        Debug.Log("0");
        if(other.tag == "MovingBall"){
            Debug.Log("1000000");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 v3Velocity = rb.velocity;
            Debug.Log(GetComponent<Rigidbody>().velocity);
            GetComponent<Rigidbody>().velocity = v3Velocity;
            Debug.Log(GetComponent<Rigidbody>().velocity);
            transform.parent = other.transform;
        }
    }
    void OnCollisonExit(Collider other){
        canJump = false;
    }
}
