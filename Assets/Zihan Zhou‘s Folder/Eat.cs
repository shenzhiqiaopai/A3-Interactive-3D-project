using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eat : MonoBehaviour
{
    public int s = 0;
    public Text tex;
    public int i = 0;
    public AudioSource AudioSource;
    public AudioClip Clip;
    // Start is called before the first frame update
    void Start()
    {
        tex.text = i.ToString() + "/10";

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Gold"))
        {
            i++;
            AudioSource.PlayOneShot(Clip);
            if (i >= 10)
            {
                SceneManager.LoadScene(s);
            }
            //AudioSource.PlayOneShot(Clip);
            tex.text =  i.ToString() + "/10";
            Destroy(other.gameObject);

        }
    }
}
