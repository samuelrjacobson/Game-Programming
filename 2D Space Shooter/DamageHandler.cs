using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health;
    float invulnTimer = 0;
    int correctLayer;
    public float invulnPeriod;
    //int killCount = 0;

    SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        correctLayer = gameObject.layer;
        spriteRend = GetComponent<SpriteRenderer>();
        //Globals.playerHealth = health;
    }

    void OnTriggerEnter2D(){
        if(gameObject.tag == "Player") Globals.playerHealth--;//health-= bulletPower;
        else health--;
        //invulnTimer = 0.50f;
        invulnTimer = invulnPeriod;
        gameObject.layer = 8;
    }

    // Update is called once per frame
    void Update(){
        if(invulnTimer > 0){
            invulnTimer -= Time.deltaTime;
            if(invulnTimer <= 0){
                gameObject.layer = correctLayer;
                if(spriteRend != null)
                    spriteRend.enabled = true;
            }else{
                if(spriteRend != null)
                    spriteRend.enabled = !spriteRend.enabled;
            }
        }
        if(gameObject.tag == "Player"){
            if(Globals.playerHealth <= 0){
                Die();
            }
        }
        else{
            if(health <= 0){
                Die();
                Globals.killCount++;
                Debug.Log("kills: " + Globals.killCount);
            }
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
