using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eunos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openEunos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("eunos");
    }
    public void closeEunos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
