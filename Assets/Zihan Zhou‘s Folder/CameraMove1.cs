using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove1 : MonoBehaviour
{
  
        public float forwardSpeed;          //前进的速度
        public float backwardSpeed;         //后退的速度
        public float rotateSpeed;           //旋转速度
        private Vector3 velocity;

        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Animator>().SetBool("open", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("open", false);

        }
        velocity = new Vector3(0, 0, v);
            velocity = transform.TransformDirection(velocity);
            if (v > 0.1)
            {
                velocity *= forwardSpeed;
            }
            else
            {
                velocity *= backwardSpeed;
            }
            transform.localPosition += velocity * Time.fixedDeltaTime;
            transform.Rotate(0, h * rotateSpeed, 0);
        }
    


}
