using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meridian : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openMeridian()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("meridian");
    }
    public void closeMeridian()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
