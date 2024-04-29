using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject score = GameObject.FindGameObjectWithTag("ScoreBox");
        score.GetComponent<TextMeshProUGUI>().text = "Game Over!\nPins knocked over: " + (10 - Globals.numPins) + "\nTime: " + Globals.score;
    }
}
