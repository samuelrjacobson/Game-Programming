using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pellet : MonoBehaviour
{

    public void OnTriggerEnter(Collider collider)
    {
        // Player eats pellet
        if (collider.tag == "Player")
        {
            Debug.Log(Globals.numEaten);

            if(++Globals.numEaten == Globals.totalPellets)
            {
                // Load next level if Pac-Man has gotten all pellets
                int scene = SceneManager.GetActiveScene().buildIndex;
                if (scene < 3) SceneManager.LoadScene (scene + 1);
                else {
                    Globals.victory = true;
                    SceneManager.LoadScene (0);
                }
            }
            else 
            {
                transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
            }
            Debug.Log(Globals.numEaten);
        }
    }

    // Called at scene load--set default global values
    public void Awake()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 3) Globals.totalPellets = 6;
        else Globals.totalPellets = scene + 2;
        Debug.Log("Pellets needed: " + Globals.totalPellets);
        Globals.numEaten = 0;
        Globals.isInvincible = false;
        Globals.currentScene = scene;
        Globals.ghostsFreed = false;
    }
}
