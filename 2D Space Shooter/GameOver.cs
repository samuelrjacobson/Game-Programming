using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject score = GameObject.FindGameObjectWithTag("ScoreBox");
        score.GetComponent<TextMeshProUGUI>().text = "Game Over!\nEnemies Destroyed: " + Globals.killCount;
    }
}
