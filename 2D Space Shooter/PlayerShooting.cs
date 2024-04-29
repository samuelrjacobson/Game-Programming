using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    int bulletLayer;

    // Start is called before the first frame update
    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownTimer <= 0){
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);

            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGo.layer = bulletLayer; // Make sure there is no friendly fire
        }
    }
}
