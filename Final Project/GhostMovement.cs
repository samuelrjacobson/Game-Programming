using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    float speed = 1;
    float xScale = 1;
    float yScale = 1;
 
    private Vector3 center;
    private Vector3 offset;
    private float currentAngle;
    private bool goingUpward = false;   
    private float nextXCoord;
    private float nextYCoord;

    // Start is called before the first frame update
    void Start() {
        center = transform.position;
    }
 
    // Update is called once per frame
    void Update () {
        offset = Vector3.up * 2 * yScale;
    
        currentAngle += speed * Time.deltaTime;
        if(currentAngle > 2 * Mathf.PI)
        {
            goingUpward = !goingUpward;
            currentAngle -= 2 * Mathf.PI;
        }
        if(currentAngle < 0) currentAngle += 2 * Mathf.PI;
    
        transform.position = center + (goingUpward ? offset : Vector3.zero);
        nextXCoord = transform.position.x + Mathf.Sin(currentAngle) * xScale;
        nextYCoord = transform.position.y + Mathf.Cos(currentAngle) * (goingUpward ? -1 : 1) * yScale;

        transform.position = new Vector3(nextXCoord, nextYCoord, 0);
    }
}
