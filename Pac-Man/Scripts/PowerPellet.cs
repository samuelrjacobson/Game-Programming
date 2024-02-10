using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour
{

    public void OnTriggerEnter(Collider collider)
    {
        // If Pac-Man eats power pellet, turn him invincible and keep power pellet at center for 5 seconds
        if (collider.tag == "Player")
        {
            Timer.startTimer(5);
            Globals.isInvincible = true;
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
    void Update ()
    {
        Timer.Update();
    }
}

// Timer for invincibility
public class Timer : MonoBehaviour
{
    public static float watch = 0;
    public static bool ticking = false;

    public static void startTimer(float time)
    {
        watch = time;
        ticking = true;
        //Debug.Log("timer start");

    }
    public static void Update()
    {
        if (ticking)
        {
            if (watch > 0)
            {
                watch -= Time.deltaTime; // subtract time of frame (Update called each frame)
            }
            else
            {
                //Debug.Log("Time up");
                ticking = false;

                // Take invincibility away
                Globals.isInvincible = false; 

                // Return Power Pellet to original position
                if (Globals.currentScene == 3)
                {
                    Globals.ghostsFreed = true;
                    GameObject.FindGameObjectWithTag("PowerPellet").transform.position = new Vector3(7.3f, 1.0f, 7.3f);
                }
                else GameObject.FindGameObjectWithTag("PowerPellet").transform.position = new Vector3(0.0f, 1.0f, 7.3f);

            }
        }
    }
}