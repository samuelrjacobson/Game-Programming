using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Goal"){
            GameObject.FindGameObjectWithTag("Wall").transform.Translate(0, -9, 0);
        }
        else if(other.tag == "OutOfBounds"){
            transform.position = new Vector3(1, 1, 5.5f);
        }
    }
}
