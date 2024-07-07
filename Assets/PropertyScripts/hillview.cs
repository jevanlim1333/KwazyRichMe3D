using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hillview : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openHillview()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("hillview");
    }
    public void closeHillview()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
