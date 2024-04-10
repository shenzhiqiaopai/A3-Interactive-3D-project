using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movex;
    private float movey;
    public float movespeed = 10;
    private int count;
    public TextMeshProUGUI  countText;
    public AudioSource pickAudio;



    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        count=0;

    }
    //Due to my character rotating 180 degrees, I multiplied the input value by -1 to reverse the direction of movement.
    public void OnMove(InputValue moveValue){
        Vector2 moveVector=moveValue.Get<Vector2>();
        movex=-moveVector.x;
        movey=-moveVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement=new Vector3(movex,0.0f,movey);
        rb.AddForce(movement*movespeed);
        SetCounterText();
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count=count +1;
            pickAudio.Play();
        }
    }

    public void SetCounterText(){
        countText.text="Score: "+count.ToString()+"/15";
    }
}
