using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //public AudioSource paddleStrike;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = .2f; // Paddle's movement speed
        if (gameObject.name == "Paddle Left")
            transform.Translate(0, Input.GetAxis("Horizontal") * speed, 0);
        else transform.Translate(0, Input.GetAxis("Vertical") * speed, 0);

    }

    /*
    Not part of assignment--extra, to finish later
    
    void onCollisonEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            Debug.Log("Paddle collide");
            paddleStrike.Play();
        }
    }*/
}
