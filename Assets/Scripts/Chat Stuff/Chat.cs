using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public InputField inputField;
    public GameObject Message;
    public GameObject Content;

    public void SendMessage()
    {
        GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, ("[CHAT] " + PhotonNetwork.NickName + " : " + inputField.text));

        inputField.text = "";
    }

    public void SendGameMessage(string message)
    {
        GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, message);
    }

    [PunRPC]
    public void GetMessage(string ReceiveMessage)
    {
        GameObject M = Instantiate(Message, Vector3.zero, Quaternion.identity, Content.transform);
        M.GetComponent<Message>().MyMessage.text = ReceiveMessage;
    }

    // leave game part below

    public void SendLeaveGameMessage(string message)
    {
        GetComponent<PhotonView>().RPC("GetLeaveGameMessage", RpcTarget.All, message);
    }

    [PunRPC]
    public void GetLeaveGameMessage(string ReceiveMessage)
    {
        GameObject M = Instantiate(Message, Vector3.zero, Quaternion.identity, Content.transform);
        M.GetComponent<Message>().MyMessage.text = ReceiveMessage;
        M.GetComponent<Message>().MyMessage.color = Color.red;
    }
}
