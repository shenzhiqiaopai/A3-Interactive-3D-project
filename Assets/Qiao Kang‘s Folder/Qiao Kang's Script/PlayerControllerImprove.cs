using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControllerImprove : MonoBehaviour
{
    private Rigidbody rb;
    private float moveDirection = 0f; // 移动方向，负值表示向后移动，正值表示向前移动
    private float rotationDirection = 0f; // 旋转方向，负值表示向右旋转，正值表示向左旋转
    public float moveSpeed = 10f; // 移动速度
    public float rotationSpeed = 100f; // 旋转速度
    public float jumpForce = 500f; // 跳跃力度
    private bool isGrounded; // 是否在地面上
    private int count;
    public TextMeshProUGUI countText;
    public AudioSource pickAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 根据按键输入调整移动方向和旋转方向
        moveDirection = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
        rotationDirection = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    void FixedUpdate()
    {
        // 应用角色移动
        rb.MovePosition(rb.position + transform.forward * moveDirection * moveSpeed * Time.fixedDeltaTime);

        // 应用角色旋转
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationDirection * rotationSpeed * Time.fixedDeltaTime, 0f));

        // 检测是否在地面上
        isGrounded = Physics.Raycast(transform.position, -transform.up, 1.1f);
        
        // 检测空格键，如果按下并且在地面上，则执行跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        
        SetCounterText();
    }

    public void OnTriggerEnter(Collider other){
    if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count=count +1;
            pickAudio.Play();
        }
    }

    public void SetCounterText()
    {
        countText.text = "Score: " + count.ToString() + "/15";
    }
}