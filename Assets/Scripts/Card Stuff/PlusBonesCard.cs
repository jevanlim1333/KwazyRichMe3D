using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlusBonesCard : Card
{
    public int bones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CardAction()
    {
        Debug.Log("Plus Bones Card Action");
        GameScript.instance.playerToken.bones += bones;
        GameScript.instance.chat.SendGameMessage("box and received " + bones + "  bones");
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " opened a Treasure");
        TileManager.instance.FinishedTileAction();
    }
}
