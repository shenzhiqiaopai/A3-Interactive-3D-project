using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCharacter : MonoBehaviour
{
    private Vector3 initialPosition;
    public Transform characterTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = characterTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCharacterPosition()
    {
        characterTransform.position = initialPosition;
    }
}
