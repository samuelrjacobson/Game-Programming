using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    //public Rigidbody rb;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Transform pivot;
    public float rotateSpeed;

    public Animator anim;

    //private int jumpCount = 0;

    private Vector3 lastPos;
    private bool jumping;
        private bool canJump;

    private Vector3 jumpPos;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement of player

        /*rb.velocity = new Vector3(Input.GetAxis("Horizontal")*movementSpeed, rb.velocity.y, Input.GetAxis("Vertical")*movementSpeed);

        if(Input.GetButtonDown("Jump")){
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }*/
        //moveDirection = new Vector3(Input.GetAxis("Horizontal")*movementSpeed, moveDirection.y, Input.GetAxis("Vertical")*movementSpeed);

        // fall back to normal speed if capslock is unpressed
        if(Input.GetKeyUp(KeyCode.CapsLock)){
            movementSpeed = 10;
        }
        // basic movement calculations
        Vector3 position1 = transform.position;
        float yStore = moveDirection.y;
        moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDirection = moveDirection.normalized * movementSpeed;
        moveDirection.y = yStore;

        // if player has moved and capslock pressed, increase movement speed
        if(transform.position != lastPos){
            if(Input.GetKeyDown(KeyCode.CapsLock)){
                movementSpeed= 20;
            }
        }

        // set updated position
        lastPos = transform.position;


        // Jumping
        // Hold spacebar longer for higher jump

        // start jump
        if(controller.isGrounded){
            moveDirection.y = 0f;
            canJump = true;
            jumping = false;
            if(Input.GetButtonDown("Jump")){
                jumpPos = transform.position;
                jumping = true;
                moveDirection.y = jumpForce;
                anim.SetBool("Jump1", true);
            }
        }
        // continue jump while able
        if(Input.GetKey(KeyCode.Space)){
            if(transform.position.y - jumpPos.y > 6){
                canJump = false;
                anim.SetBool("Jump1", false);
            }
            if(jumping && canJump) moveDirection.y = jumpForce;
        }
        // prematurely stop jump
        if(Input.GetButtonUp("Jump")){
            canJump = false;
            anim.SetBool("Jump1", false);
        }

        /*
        // Double jump
        if(controller.isGrounded){
            moveDirection.y = 0f;
            jumpCount = 0;
            /*if(Input.GetButtonDown("Jump")){
                moveDirection.y = jumpForce;
            }
        }
        if(Input.GetButtonDown("Jump")){
            if (jumpCount == 0){
                moveDirection.y = jumpForce;
                jumpCount++;
                anim.SetBool("Jump1", true);
            }
            else if (jumpCount == 1){
                moveDirection.y = jumpForce;
                jumpCount++;
                anim.SetBool("Jump1", false);
                anim.SetBool("Jump2", true);
            }
            else {
                anim.SetBool("Jump2", false);
            }
        }*/

        // player movement
        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
        
        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical"))+Mathf.Abs(Input.GetAxis("Horizontal"))));
        
    }
}
