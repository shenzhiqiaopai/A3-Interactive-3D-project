using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float MoveSpeed;

    private float horizontal;
    private float vertical;

    private float gravity = 9.8f;
    public float JumpSpeed = 15f;
    public CharacterController PlayerController;
    public Transform CameraRotation;

    private float Mouse_X;
    private float Mouse_Y;

    public float MouseSensitivity;

    public float xRotation;
    Vector3 Player_Move;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Animator>().SetBool("open", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("open", false);

        }
        Mouse_X = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        Mouse_Y = Input.GetAxis("Mouse Y") * 0 * Time.deltaTime;

        xRotation = xRotation - Mouse_Y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        CameraRotation.Rotate(Vector3.up * Mouse_X);

        CameraRotation.Rotate(-Vector3.right * Mouse_Y);
        CameraRotation.localEulerAngles = new Vector3(CameraRotation.localEulerAngles.x, CameraRotation.localEulerAngles.y, 0);
        if (PlayerController.isGrounded)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            Player_Move = (transform.forward * vertical + transform.right * horizontal) * MoveSpeed;

            if (Input.GetAxis("Jump") == 1)
            {
                Player_Move.y = Player_Move.y + JumpSpeed;
            }
        }

        Player_Move.y = Player_Move.y - gravity * Time.deltaTime;

        PlayerController.Move(Player_Move * Time.deltaTime);
    }

}
