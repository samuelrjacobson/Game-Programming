using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    GameObject collectibleInstance;
    float killCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.killCount > 0 && Globals.killCount % 30 == 0){   // if num kills is multiple of 15
            if(killCount < Globals.killCount){
                spawn();
            }
            killCount = Globals.killCount;
        }
    }

    public void spawn(){
        float xCoord = Random.Range(-110, 100);
        float yCoord = Random.Range(-20, 20);
        Vector3 offset = new Vector3(xCoord, yCoord, 0);
        //offset = offset.normalized * spawnDistance;
        Instantiate(collectiblePrefab, transform.position + offset, Quaternion.identity);
    }
}
