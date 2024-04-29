using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float startX = 0;
    public float startY = 15;
    //public float startZ = -175;
    public float startZ = -67;
    private Vector3 startLocation;

    private float completionTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Globals.startLocation = new Vector3(startX, startY, startZ);    // initial location
        GameObject.FindGameObjectWithTag("Player").transform.position = Globals.startLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.numPins > 0)
            completionTime += Time.deltaTime;

        else {
            Globals.score = completionTime;
            SceneManager.LoadScene(2);
        }
    }

    //script attached to floor
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Debug.Log("Hey");
            if (Globals.numAttempt == 0){
                            Debug.Log("0");
                other.transform.position = Globals.startLocation;
                GameObject.FindGameObjectWithTag("MainCamera").transform.position = Globals.startLocation;
                Globals.numAttempt = 1;
                GameObject.FindGameObjectWithTag("Ghost").transform.position = new Vector3(8.4f, 20, 73);
            }
            else {
                Globals.score = completionTime;
                SceneManager.LoadScene(3);
            }
        }
    }
}


