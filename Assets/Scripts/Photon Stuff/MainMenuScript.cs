using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        PhotonNetwork.Disconnect();
    }
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
