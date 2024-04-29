using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

static class Globals
{
    public static int currentScene = 0; // holds current level number
}
public class GameManager : MonoBehaviour
{
    public int currentGold;
    public Text goldText;
    public int totalGold = 6;

    public void AddGold(int goldToAdd)  // increment gold counter
    {
        currentGold += goldToAdd;
        goldText.text = "Gold: " + currentGold + "/" + totalGold;

        if(currentGold == totalGold) {      // load next level if we've collected all gold
            if(Globals.currentScene < 2){
                SceneManager.LoadScene(++Globals.currentScene);
            }
            else {
                Globals.currentScene = 0;
                SceneManager.LoadScene(0);
            }
        }
    }
}
