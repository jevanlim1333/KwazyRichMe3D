using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dakota : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openDakota()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("dakota");
    }
    public void closeDakota()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
