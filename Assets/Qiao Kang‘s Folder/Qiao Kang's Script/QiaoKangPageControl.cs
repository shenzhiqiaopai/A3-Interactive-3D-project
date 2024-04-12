using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QiaoKangPageControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumeHome()
    {
        SceneManager.LoadScene("Home Page");
    }

    public void JumeQiaoKangPage()
    {
        SceneManager.LoadScene("Qiao Kang's Scene");
    }
}
