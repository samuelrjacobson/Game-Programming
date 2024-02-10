using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

static class Globals
{
    public static int leftScore = 0;
    public static int rightScore = 0;
    public static Vector3 blue = new Vector3(0,0,1);
    public static Vector3 red = new Vector3(1,0,0);

}

public class RightGoal : MonoBehaviour
{
    public AudioSource p1w;
    public AudioSource score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        // Count as score for Left Team
        Globals.leftScore++;
        Debug.Log("Left Team scores! Score is " + Globals.leftScore + "-" + Globals.rightScore);
        GameObject lsc = GameObject.Find("Canvas/Left Score Counter");

        lsc.GetComponent<TextMeshProUGUI>().text = "" + Globals.leftScore;

        // End game if score hits 3
        if (Globals.leftScore == 3)
        {
            Debug.Log("Left Team wins!");
            p1w.Play();
        }
        else {
            // Wait one second before respawning
            System.Threading.Thread.Sleep(1000);

            // Play score audio
            score.Play();

            // Move ball back to center
            collider.gameObject.transform.position = new Vector3(0.0f, 1.0f, 0.0f);

            // Reassign random velocity to ball
            // Make ball start towards opposite goal
            float speedX = -1;
            float speedY = Random.Range(0, 2) == 0 ? -1 : 1;

            collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range(5, 10) * speedX, Random.Range(5, 10) * speedY, 0);
        
        }
    }

}
