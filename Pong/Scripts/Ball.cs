//using System;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.Specialized;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speedX;
    float speedY;

    // Start is called before the first frame update
    void Start()
    {
        // assign random direction to sphere
        // returns 0 or 1. If 0, give negative velocity
        speedX = Random.Range(0, 2) == 0 ? -1 : 1;
        speedY = - Random.Range(0, 2) == 0 ? -1 : 1;

        // speed
        GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range(5, 10) * speedX, Random.Range(5, 10) * speedY, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

