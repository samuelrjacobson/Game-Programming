using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;

    public float fireDelay = 1.50f;
    float cooldownTimer = 0;
    int bulletLayer;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){ // Need to locate the player
            //GameObject go = GameObject.Find("PlayerShip");
            GameObject go = GameObject.FindWithTag("Player");
            if(go != null)
                player = go.transform;
        }
        cooldownTimer -= Time.deltaTime;
        if(cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4){
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGo.layer = bulletLayer; // Make sure there is no friendly fire
        }
    }
}
