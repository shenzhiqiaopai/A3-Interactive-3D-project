using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private float moveDirection = 0f; //Moving direction, negative value means moving backward, positive value means moving forward
    private float rotationDirection = 0f; // Rotation direction, negative value means rotation to the right, positive value means rotation to the left
    public float moveSpeed = 10f; // Moving speed
    public float rotationSpeed = 100f; // spinning speed
    public float jumpForce = 500f; // Jump power
    private bool isGrounded; // whether on the ground
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

        moveDirection = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
        rotationDirection = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    void FixedUpdate()
    {
       
        rb.MovePosition(rb.position + transform.forward * moveDirection * moveSpeed * Time.fixedDeltaTime);

        
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationDirection * rotationSpeed * Time.fixedDeltaTime, 0f));

     
        isGrounded = Physics.Raycast(transform.position, -transform.up, 1.1f);
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        
        SetCounterText();
        if (count >= 10)
        {
          
            SceneManager.LoadScene("Zihan Zhou's Scene 1"); 
        }

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
        countText.text = "Score: " + count.ToString() + "/10";
    }
}
