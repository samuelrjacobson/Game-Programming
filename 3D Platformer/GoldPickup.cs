using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        value = 1;
    }

    // pick up gold 
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            FindObjectOfType<GameManager>().AddGold(value);
            Destroy(gameObject);
        }
    }
}
