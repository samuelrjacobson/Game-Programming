using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLeave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }
 
    // Update is called once per frame
    void Update () {
        transform.Translate(Time.deltaTime * 0.6f, 0, 0);
    }
}
