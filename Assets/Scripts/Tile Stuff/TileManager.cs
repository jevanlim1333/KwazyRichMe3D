using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TileManager : MonoBehaviourPunCallbacks
{
    /*
                                    Types of Tiles
            1. Property     2. Treasure Box     3. Toy
            5. Treat        5. Charity          6. Nap Time (Property kinda)
    */
    public static TileManager instance;
    public PhotonView view;
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
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void GetPurchaseProperty(Player player, int tileNumber)
    {
        Property toPurchase = (Property) GameScript.instance.allRoutes.tilesArray[tileNumber];
        toPurchase.ownedBy = player;
    }

    [PunRPC]
    public void GetPurchaseToy(Player player, int tileNumber)
    {
        Toy toPurchase = (Toy) GameScript.instance.allRoutes.tilesArray[tileNumber];
        toPurchase.ownedBy = player;
    }

    public void FinishedTileAction()
    {     
        GameScript.instance.GetComponent<PhotonView>().RPC("SetNextPlayer", RpcTarget.All);
        GameScript.instance.GetComponent<PhotonView>().RPC("SetRolling", RpcTarget.All, false);
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " end their turn");
    }

    [PunRPC]
    public void GetRentPayment(int rent)
    {
        GameScript.instance.playerToken.bones += rent;
    }

    public void SendTreatResult(int result)
    {
        GameScript.instance.playerToken.bones += result;
        if (result > 0)
        {
            GameScript.instance.chat.SendGameMessage("wheel and received " + result + " bones");
            GameScript.instance.chat.SendGameMessage("[GAME]" + PhotonNetwork.LocalPlayer.NickName + " spinned the lucky" );
        }
        else
        {
            int lostBones = result * -1;
            GameScript.instance.chat.SendGameMessage("wheel and lost " + lostBones + " bones");
            GameScript.instance.chat.SendGameMessage("[GAME]" + PhotonNetwork.LocalPlayer.NickName + " spinned the lucky" );
        }
        
        TileManager.instance.FinishedTileAction();
    }
}
