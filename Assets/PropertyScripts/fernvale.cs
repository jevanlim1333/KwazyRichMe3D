using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fernvale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openFernvale()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("fernvale");
    }
    public void closeFernvale()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
