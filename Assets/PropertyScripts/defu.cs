using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDefu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("defu");
    }
    public void closeDefu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
