using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartley : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openBartley()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("bartley");
    }
    public void closeBartley()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
