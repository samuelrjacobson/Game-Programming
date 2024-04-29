using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour 
{
    //private bool knocked = false;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
    }
    void OnTriggerEnter(Collider other){
        //Debug.Log("collision");
        //if(other.tag == "Player" || other.tag == "Pin"){
        if(other.tag == "OutOfBounds"){
            //Debug.Log("contact");
            //if(!knocked){
                Globals.numPins = Globals.numPins - 1;
                Debug.Log("Num pins: " + Globals.numPins);
                //Destroy(gameObject);
              //  knocked = true;
            //}
        }   
    }
}
