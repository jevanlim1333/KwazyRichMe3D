using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NapTime : Tile
{
    public static NapTime instance;
    public int numberOfRoundsSkip;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TileAction()
    {
        if (numberOfRoundsSkip == 0) // just landed on nap time
        {
            numberOfRoundsSkip = 3;
            GameScript.instance.chat.SendGameMessage("and will be napping for 3 rounds");
            GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " landed on Nap Time");
        }
        else if (numberOfRoundsSkip == 1) // last nap round
        {
            numberOfRoundsSkip = 0;
            GameScript.instance.chat.SendGameMessage("will be awake next round");
            GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " is napping");
        }
        else // currently nap time
        {
            numberOfRoundsSkip--;
            GameScript.instance.chat.SendGameMessage("" + numberOfRoundsSkip + " more rounds");
            GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " is napping for");
        }
        TileManager.instance.FinishedTileAction();
    }
}
