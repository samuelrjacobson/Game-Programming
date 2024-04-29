using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Trailer : MonoBehaviour
{
    private GameObject storyBox;

    private string[] storyLines = {
        "Gregory used to be a happy, lively bowler.",
        "One day, he threw the ball too hard,",
        "And his arm fell off",
        "And then he died",
        "Which pissed him off a little",
        "Because people became afraid to use that bowling lane anymore.",

        "Now, he haunts that very lane",
        "To make it more interesting",
        "And inspire people to try it out....",
        "Haunted\nBowling\nLane"
    };

    private int index = 0;

    public void Start(){
        storyBox = GameObject.FindGameObjectWithTag("ScoreBox");
        storyBox.GetComponent<TextMeshProUGUI>().text = storyLines[index++];
    }
    public void Update(){

        if(Input.GetKeyDown(KeyCode.Space)){
            if(index < storyLines.Length){
                storyBox.GetComponent<TextMeshProUGUI>().text = storyLines[index++];
            }
            else {
                SceneManager.LoadScene(0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene(0);
        }
    }
}
