using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffset;
    public float rotateSpeed;
    //public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        if(!useOffset) offset = target.position - transform.position;

        //.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        //pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //pivot.transform.position = target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);
        //pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(-vertical, 0, 0);

        if(invertY)
            target.Rotate(vertical, 0, 0);
        else 
            target.Rotate(-vertical, 0, 0);

        if(target.rotation.eulerAngles.x > maxViewAngle && target.rotation.eulerAngles.x < 180f)
            target.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        if(target.rotation.eulerAngles.x > 180f && target.rotation.eulerAngles.x < 360f+minViewAngle)
            target.rotation = Quaternion.Euler(360f+minViewAngle, 0, 0);
        //float yAngle = target.eulerAngles.y;
        float yAngle = target.eulerAngles.y;
        // float xAngle = target.eulerAngles.x;
        float xAngle = target.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.position - rotation * offset;
        //transform.position = target.position - offset;

        if(transform.position.y < target.position.y)
            transform.position = new Vector3(transform.position.x, target.position.y -.5f, transform.position.z);
        transform.LookAt(target);        
    }
}
