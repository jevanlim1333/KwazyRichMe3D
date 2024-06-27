using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punggol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openPunggol()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("punggol");
    }
    public void closePunggol()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
