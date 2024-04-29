using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //GameObject[] enemies = new GameObject[3];

    public GameObject enemyPrefab;
    /*public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    enemies[0] = enemyPrefab1;
    enemies[1] = enemyPrefab2;
    enemies[2] = enemyPrefab3;*/

    float spawnDistance = 20f;

    public float secondsTillEnemySpawn;
    float enemyRate;
    float nextEnemy = 1;
    //float numEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyRate = secondsTillEnemySpawn;
    }

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;
        if(nextEnemy <= 0){
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;
            if(enemyRate < secondsTillEnemySpawn / 2)
                enemyRate = secondsTillEnemySpawn / 2;
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;
            //if(numEnemies++ < 10)
                Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}
