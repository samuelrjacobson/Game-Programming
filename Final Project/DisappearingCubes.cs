using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingCubes : MonoBehaviour
{
    private bool disappeared = false;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("flashRed", 0.75f, 0.75f);
    }

    // Update is called once per frame
    void Update(){

    }
    void removeCube(){
        transform.Translate(0, -10, 0);
        Invoke("returnCube", 1f);
    }
    void flashRed(){
        if(!disappeared && Random.Range(0, 6) == 0){
            Invoke("removeCube", 0.75f);
            disappeared = true;
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        }
    }
    void returnCube(){
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        transform.Translate(0, 10, 0);
        disappeared = false;
    }
}
