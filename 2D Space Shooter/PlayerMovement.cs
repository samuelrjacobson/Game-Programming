using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    float rotSpeed = 180f;

    float shipBoundaryRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        // Restrict the player to the camera's boundaries
        if(pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        if(pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if(pos.x + shipBoundaryRadius > widthOrtho)
            pos.x = widthOrtho - shipBoundaryRadius;
        if(pos.x - shipBoundaryRadius < -widthOrtho)
            pos.x = -widthOrtho + shipBoundaryRadius;

        transform.position = pos;
    }
}
