using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardMovement : MonoBehaviour
{
    public float startX;
    public float startY;
    public float startZ;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(startX, startY, startZ);
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -0.05f, 0f);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "OutOfBounds"){
            transform.position = startPos;
        }
    }
}
