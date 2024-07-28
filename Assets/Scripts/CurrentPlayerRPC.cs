using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class CurrentPlayerRPC : MonoBehaviour
{
    public static CurrentPlayerRPC  instance;
    public TMP_Text currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendCurrentPlayerInfo()
    {
        GetComponent<PhotonView>().RPC("GetCurrentPlayerInfo", RpcTarget.All, 
        PhotonNetwork.LocalPlayer.ActorNumber, PhotonNetwork.LocalPlayer.NickName);
    }

    [PunRPC]
    public void GetCurrentPlayerInfo(int number, string name)
    {
        currentPlayer.text = "Current Player: (" + number + ") " + name; 
    }
}
