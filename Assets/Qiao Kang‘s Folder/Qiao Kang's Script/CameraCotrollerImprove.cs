using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotrollerImprove : MonoBehaviour
{
    public Transform target;    //Camera follows target
    public float xSpeed = 200;  //Drag speed in X-axis direction
    public float ySpeed = 200;  //Drag speed in Y-axis direction
    public float mSpeed = 10;   //Zoom in and out speed
    public float yMinLimit = -50; //Minimum movement range on Y axis
    public float yMaxLimit = 50; //Maximum movement range on Y axis
    public float distance = 10;  //camera viewing distance
    public float minDinstance = 2; //Camera viewing angle minimum distance
    public float maxDinstance = 30; //Camera viewing angle maximum distance
    public float x = 0.0f;
    public float y = 0.0f;
    public float damping = 5.0f;
    public bool needDamping = true;
 
 
    
    void Start()
    {
        Vector3 angle = transform.eulerAngles;
        x = angle.y;
        y = angle.x;
    }
 
    
    void LateUpdate() //camera part
    {
        if (target)
        {
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                y = ClamAngle(y, yMinLimit, yMaxLimit);
 
            }
            distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
            distance = Mathf.Clamp(distance, minDinstance, maxDinstance);
            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
            Vector3 disVector = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * disVector + target.position;

            // If the camera position is below 3, move it above the position of 0
            if (position.y < 3)
            {
                position.y = 3;
            }
 
            if (needDamping)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
            }
            else
            {
                transform.rotation = rotation;
                transform.position = position;
            }
        }
    }
    
    static float ClamAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

}
