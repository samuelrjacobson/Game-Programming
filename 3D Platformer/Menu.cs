using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // load level corresponding to button
    public void buttonClick1(){
        Globals.currentScene = 1;
        SceneManager.LoadScene(1);
    }
    public void buttonClick2(){
        Globals.currentScene = 2;
        SceneManager.LoadScene(2);
    }
}
