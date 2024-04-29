using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public int numSeconds; 
    public float speedX;
    public float speedY;
    public float speedZ;
    private Vector3 directionNeg;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Timer.startTimer(numSeconds);

        direction = new Vector3(speedX, speedY, speedZ);    // initial movement

        // calculate negation of value for direction change
        if(speedX != 0) directionNeg = new Vector3(-1, 0, 0);
        else if(speedY != 0) directionNeg = new Vector3(0, -1, 0);
        else directionNeg = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedX, speedY, speedZ);
        // Each time timer runs, it returns opposite boolean value compared to previous time. Change direction each time.
        //if (Timer.Update()) transform.Translate(speedX, speedY, speedZ);
        //else transform.Translate(Vector3.Scale(direction, directionNeg));
    }
    /*void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player on moving obj");
            other.gameObject.transform.Translate(speedX, speedY, speedZ);
        }
    }*/
    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Character"){
            Debug.Log("Player on moving platform");
            other.gameObject.transform.parent.Translate(speedX, speedY, speedZ);
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "MoveBoundary"){
            speedX *= -1;
            speedY *= -1;
            speedZ *= -1;

            //GetComponent<Rigidbody>().velocity = new Vector3(-speedX, -speedY, -speedZ);
        }
    }
}

// Timer for direction change
public class Timer : MonoBehaviour
{
    public static float watch = 0;
    public static bool ticking = false;
    public static bool directionRight = true;
    public static float t;

    public static void startTimer(float time)
    {
        watch = time;
        ticking = true;
        t = time;
    }
    public static bool Update()
    {
        if (ticking)
        {
            if (watch > 0)
            {
                watch -= Time.deltaTime; // subtract time of frame (Update called each frame)
            }
            else
            {
                ticking = false;

                directionRight = !directionRight;

                startTimer(t);

                return directionRight;       
            }
        }
        return directionRight;
    }
}
