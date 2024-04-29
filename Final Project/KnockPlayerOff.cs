using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockPlayerOff : MonoBehaviour
{
    private GameObject target=null;
    private Vector3 offset;

    void Start(){
        target = null;
    }

    void OnTriggerStay(Collider other){
        if(other.tag == "Player"){
            target = other.gameObject;
            offset = target.transform.position - transform.position;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            target = null;
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0);
        }
    }

    void LateUpdate(){
        if (target != null) {
            target.transform.position = transform.position+offset;
        }
    }
}
