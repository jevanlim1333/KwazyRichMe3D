using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedok : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openBedok()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("bedok");
    }
    public void closeBedok()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
