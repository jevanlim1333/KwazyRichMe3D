using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sengkang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openSengkang()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("sengkang");
    }
    public void closeSengkang()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
