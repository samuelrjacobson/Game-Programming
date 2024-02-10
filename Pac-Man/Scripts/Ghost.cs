using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public GameObject target; //ghost's target (the player)
    UnityEngine.AI.NavMeshAgent agent; //self reference to the ghost game object

    (bool eaten, bool jailed) ghost = (false, false);

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Update target location if ghost has not been eaten
        if (!ghost.eaten || Globals.ghostsFreed)
            agent.destination = target.transform.position;
        else
        {
            // Keep ghost in jail if it has been eaten
            agent.gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        //JailTimer.Update();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // When ghost collides with player
        {
            if (!Globals.isInvincible) // Normally, reload menu, Pac-Man loses
                SceneManager.LoadScene("Menu");
            // If Pac-Man is invincible, move ghost to jail
            else
            {
                agent.gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                ghost.eaten = true;
                //ghostsFreed = false;
                //ghost.jailed = true;
                //JailTimer.startTimer(ghost, 10);
            }
        }
    }
    
}