using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonOnCilk1 : MonoBehaviour
{
    public GameObject MusicBut;
    bool isopen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mu()
    {
        if (!isopen)
        {

            MusicBut.GetComponent<AudioSource>().enabled = false;
            isopen = true;
        }
        else
        {
            isopen = false;

            MusicBut.GetComponent<AudioSource>().enabled = true;

        }
    }
}
