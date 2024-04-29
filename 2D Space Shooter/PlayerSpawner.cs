using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;

    public int numLives = 4;

    float respawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        Globals.playerHealth = 5;
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update(){
        if(playerInstance == null && numLives > 0){
            respawnTimer -= Time.deltaTime;
            if(respawnTimer <= 0)
                SpawnPlayer();
        }
        else if(numLives == 0){
            SceneManager.LoadScene(1);
        }

        GameObject score = GameObject.FindGameObjectWithTag("inGameUI");
        score.GetComponent<TextMeshProUGUI>().text = "Health: " + Globals.playerHealth + "\nLives left: " + numLives + "\nKills: " + Globals.killCount;
    }

    /*void OnGUI()    // Outdated
    {
        if(numLives > 0 || playerInstance != null){
            GUI.Label(new Rect(0, 0, 100, 50), "Health: " + Globals.playerHealth + "\nLives left: " + numLives + "\nKills: " + Globals.killCount);
            //GUI.Label(new Rect(0, 0, 100, 50), "Lives left: " + numLives);
        }
        else
            GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 - 25, 100, 50), "Game over!");
    }*/
}
