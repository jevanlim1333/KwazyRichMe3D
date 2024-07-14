using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class BonesCounter : MonoBehaviour
{
    public PlayerNickname player1;
    public PlayerNickname player2;
    public PlayerNickname player3;
    public PlayerNickname player4;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setToken(int tokenNumber, Token token)
    {
        if (tokenNumber == 1)
        {
            player1.SetToken(token);
        }
        if (tokenNumber == 2)
        {
            player2.SetToken(token);
        }
        if (tokenNumber == 3)
        {
            player3.SetToken(token);
        }
        if (tokenNumber == 4)
        {
            player4.SetToken(token);
        }
    }
}