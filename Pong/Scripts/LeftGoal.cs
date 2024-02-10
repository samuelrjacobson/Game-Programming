using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class LeftGoal : MonoBehaviour
{
    public AudioSource p2w;
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
        // Count as score for Right Team
        Globals.rightScore++;
        Debug.Log("Right Team scores! Score is " + Globals.leftScore + "-" + Globals.rightScore);
        GameObject rsc = GameObject.FindGameObjectWithTag("RightScoreCounter");
        rsc.GetComponent<TextMeshProUGUI>().text = "" + Globals.rightScore;

        // End game if score hits 3
        if (Globals.rightScore == 3)
        {
            Debug.Log("Right Team wins!");
            p2w.Play();
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
            float speedX = 1;
            float speedY = Random.Range(0, 2) == 0 ? -1 : 1;

            collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range(5, 10) * speedX, Random.Range(5, 10) * speedY, 0);
        
        }
    }
}
