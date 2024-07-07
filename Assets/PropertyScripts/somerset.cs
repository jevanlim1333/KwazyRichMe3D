using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somerset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openSomerset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("somerset");
    }
    public void closeSomerset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
