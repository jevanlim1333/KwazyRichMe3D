using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openNovena()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("novena");
    }
    public void closeNovena()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
