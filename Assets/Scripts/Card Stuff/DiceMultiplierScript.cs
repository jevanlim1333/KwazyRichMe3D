using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DiceMultiplierScript : Card
{
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
        int mutiplier = GameScript.instance.dice1result + GameScript.instance.dice2result;
        int bonesToReceive = 500 * mutiplier;
        GameScript.instance.playerToken.bones += bonesToReceive;
        GameScript.instance.chat.SendGameMessage("box and received " + bonesToReceive + "  bones");
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " opened a Treasure");
        TileManager.instance.FinishedTileAction();
    }
}
