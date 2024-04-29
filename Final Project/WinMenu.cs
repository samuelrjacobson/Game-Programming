using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject score = GameObject.FindGameObjectWithTag("ScoreBox");
        score.GetComponent<TextMeshProUGUI>().text = "Congratulations!\nPins knocked over: " + (10 - Globals.numPins) + "\nTime: " + Globals.score;

        GameObject highScoreBox = GameObject.FindGameObjectWithTag("HighScoreBox");
        if (Globals.score < Globals.highScore){
            highScoreBox.GetComponent<TextMeshProUGUI>().text = "New high score!";
            Globals.highScore = Globals.score;
        }
        else {
            highScoreBox.GetComponent<TextMeshProUGUI>().text = "High score: " + Globals.highScore;
        }
    }
}
