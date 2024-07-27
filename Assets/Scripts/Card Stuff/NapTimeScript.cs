using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NapTimeScript : Card
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
        Debug.Log("Nap Time Card Action");
        GameScript.instance.playerToken.currPos = 20;
        GameScript.instance.playerGameObject.transform.position = GameScript.instance.playerToken.thisRoute[20];
        GameScript.instance.allRoutes.tilesArray[20].TileAction();
        GameScript.instance.chat.SendGameMessage("box and goes to nap");
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " opened a Treasure");
    }
}
