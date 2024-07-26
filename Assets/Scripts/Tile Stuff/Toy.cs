using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Toy : Tile
{
    public string PropertyName;
    public int cost;
    public int basicRent;
    public int setRent;
    public int rent;
    public ToyCanvas propertyCanvas;
    public Player ownedBy;
    public List<Toy> otherProperties;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // updating of owned by text
        if (ownedBy != null) 
        {
            propertyCanvas.ownedByText.text = "Owned By: " + ownedBy.NickName;
        }

        // updating of rent
        if (ownedBy != null) //current property owned
        {
            bool allOwnedBySamePlayer = true;
            foreach (Toy otherToy in otherProperties)
            {
                if (otherToy.ownedBy == null) // property unowned
                {
                    allOwnedBySamePlayer = allOwnedBySamePlayer && false;
                }
                else if (otherToy.ownedBy.Equals(ownedBy)) // tpropertyile same owner
                {
                    allOwnedBySamePlayer = allOwnedBySamePlayer && true;
                }
                else 
                { // property different owner
                    allOwnedBySamePlayer = allOwnedBySamePlayer && false;
                }
            }

            if (allOwnedBySamePlayer) // all owned by same player
            {
                rent = basicRent;
            }
            else // not all owned by same player
            {
                rent = setRent;
            }
        }
    }
    public override void TileAction()
    {
        if (ownedBy == null) // not owned
        {
            propertyCanvas.Purchasing();
        } 
        else if (!ownedBy.Equals(PhotonNetwork.LocalPlayer)) // owned by someone else
        {
            SendPropertyRentPayment();
        }
        else // owned by LocalPlayer
        {
            TileManager.instance.FinishedTileAction();
        }
    }

    public void SendPurchaseProperty()
    {
        GameScript.instance.playerToken.bones -= cost;
        GameScript.instance.chat.SendGameMessage("" + PropertyName + " for " + cost);
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " purchased ");
        TileManager.instance.GetComponent<PhotonView>().RPC("GetPurchaseToy", RpcTarget.All, PhotonNetwork.LocalPlayer, tileNumber);
        TileManager.instance.FinishedTileAction();
    }

    public void SendPropertyRentPayment()
    {
        int multiplier = GameScript.instance.dice1result + GameScript.instance.dice2result;
        int amountToPay = rent * multiplier;
        GameScript.instance.playerToken.bones -= amountToPay;
        GameScript.instance.chat.SendGameMessage("and paid " + ownedBy.NickName + " " + amountToPay);
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " landed on " + PropertyName);
        TileManager.instance.GetComponent<PhotonView>().RPC("GetRentPayment", ownedBy, amountToPay);
        TileManager.instance.FinishedTileAction();
    }
}
