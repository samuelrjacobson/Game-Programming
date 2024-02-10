using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void buttonClick()
    {
        // If player passed all levels, return to beginning. Otherwise, load whichever scene the player just failed on
        if (Globals.victory) SceneManager.LoadScene(1);
        else SceneManager.LoadScene(Globals.currentScene);
    }
}
