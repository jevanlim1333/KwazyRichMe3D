using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Charity : Tile
{
    public override void TileAction()
    {
        GameScript.instance.playerToken.bones -= 1500;
        GameScript.instance.chat.SendGameMessage("and paid 1500 bones");
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " landed on Charity ");
        TileManager.instance.FinishedTileAction();
    }
}
