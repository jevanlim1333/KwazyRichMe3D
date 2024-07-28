using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Play() 
    {
        SceneManager.LoadScene("loading");
        Debug.Log("Load loading scene");
    }
    public void Quit() 
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
