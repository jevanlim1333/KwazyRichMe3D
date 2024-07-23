using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TileManager : MonoBehaviourPunCallbacks
{
    /*
                                    Types of Tiles
            1. Breakfast Time     2. Property     3. Treasure Box     4. Toy
            5. Treat              6. Charity      7. Nap Time
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

    public void FinishedTileAction()
    {     
        GameScript.instance.GetComponent<PhotonView>().RPC("SetNextPlayer", RpcTarget.All);
        GameScript.instance.GetComponent<PhotonView>().RPC("SetRolling", RpcTarget.All, false);
    }

    [PunRPC]
    public void GetPropertyRentPayment(int rent)
    {
        GameScript.instance.playerToken.bones += rent;
    }
}
