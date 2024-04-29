using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectMenu : MonoBehaviour
{
    //private float time = 0;
    private float red;
    private float green;
    private float blue;
    private GameObject selectButton;
    //private GameObject ball;

    public void Start(){
        //selectButton = GameObject.FindGameObjectWithTag("Button");
        //selectButton.GetComponent<TextMeshProUGUI>().text = "Select color: Black";
        red = 0;
        green = 0;
        blue = 0;
        //ball = GameObject.FindGameObjectWithTag("Ball");
    }
    public void Update(){
        //time += Time.deltaTime;

        gameObject.GetComponent<Renderer>().material.color = new Color(red, green, blue);   //ball color

        Globals.ballRed = red;
        Globals.ballGreen = green;
        Globals.ballBlue = blue;


        if(Input.GetKeyDown(KeyCode.Space)){
            toggleColor();
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            Globals.ballRed = red;
            Globals.ballGreen = green;
            Globals.ballBlue = blue;
            Globals.score = 0;
            Globals.numPins = 10;
            Globals.numAttempt = 0;
            SceneManager.LoadScene(1);
        }
    }
    public void toggleColor(){
        if(red == 0 && green == 0 && blue == 0){
            red = 1;
            //selectButton.GetComponent<TextMeshProUGUI>().text = "Select color: Red";
        }
        else if(red == 1 && green == 0 && blue == 0){
            red = 0;
            green = 1;
            //selectButton.GetComponent<TextMeshProUGUI>().text = "Select color: Green";
        }
        else if(red == 0 && green == 1 && blue == 0){
            green = 0;
            blue = 1;
            //selectButton.GetComponent<TextMeshProUGUI>().text = "Select color: Blue";
        }
        else if(red == 0 && green == 0 && blue == 1){
            blue = 0;
            //selectButton.GetComponent<TextMeshProUGUI>().text = "Select color: Black";
        }
    }
    /*void buttonClick()
    {
        if(red == 1)
            Globals.ballRed = 1;
        else if(green == 1)
            Globals.ballGreen = 1;
        else if(blue == 1)
            Globals.ballBlue = 1;
        SceneManager.LoadScene(1);
    }
/*
        if((int)time % 4 == 0){
            GameObject ball = GameObject.FindGameObjectWithTag("uiBox");
            ball.GetComponent<TextMeshProUGUI>().text = "Select color: Red";
            red = true;
            green = false;
        }
        else if((int)time % 4 == 1){
            GameObject ball = GameObject.FindGameObjectWithTag("uiBox");
            ball.GetComponent<TextMeshProUGUI>().text = "Select color: Green";
            green = true;
            red = false;
        }
        else if((int)time % 4 == 1){
            GameObject ball = GameObject.FindGameObjectWithTag("uiBox");
            ball.GetComponent<TextMeshProUGUI>().text = "Select color: Green";
            green = true;
            red = false;
        }
        else {
            GameObject ball = GameObject.FindGameObjectWithTag("uiBox");
            ball.GetComponent<TextMeshProUGUI>().text = "Select color: Blue";
            green = false;
            red = false;
        }
    }
    */
}
