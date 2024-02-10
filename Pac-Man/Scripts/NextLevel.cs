using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        // load next level on collision
        if (collider.tag == "Player")
        {
            Globals.isInvincible = false;
            int scene = SceneManager.GetActiveScene().buildIndex;
            if (scene < 3) SceneManager.LoadScene (scene + 1);
            else SceneManager.LoadScene (0);
        }
    }
}
