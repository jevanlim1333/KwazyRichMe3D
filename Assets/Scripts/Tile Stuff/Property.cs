using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Property : Tile
{
    public string PropertyName;
    public int basicRent;
    public int setRent;
    public int rent;
    public PropertyCanvas propertyCanvas;
    public Player ownedBy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ownedBy != null)
        {
            propertyCanvas.ownedByText.text = "Owned By: " + ownedBy.NickName;
        }
    }
    public override void TileAction()
    {
        propertyCanvas.Purchasing();
    }

    public void SendPurchaseProperty()
    {
        GameScript.instance.chat.SendGameMessage("" + PropertyName + " for " + rent);
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " purchased ");
        TileManager.instance.GetComponent<PhotonView>().RPC("GetPurchaseProperty", RpcTarget.All, PhotonNetwork.LocalPlayer, tileNumber);
        TileManager.instance.FinishedTileAction();
    }

}
