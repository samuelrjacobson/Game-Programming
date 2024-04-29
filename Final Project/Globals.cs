using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static class Globals
{
    public static float score = 0;
    public static int numPins = 10;
    public static Vector3 startLocation;

    public static float ballRed;
    public static float ballGreen;
    public static float ballBlue;

    public static int numAttempt = 0;

    public static float highScore = float.MaxValue;

}
public class starting{
    void Awake(){
        SceneManager.LoadScene(4);
    }
}