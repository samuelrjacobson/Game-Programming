using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour
{
    Transform player;
    float rotSpeed = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if(player == null)
            return;     // Try again next frame

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);

    }
}
