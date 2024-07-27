using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GoToScript : Card
{
    public int goToLocation;
    public string locationName;
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
        Debug.Log("Go To Card Action");
        int currLocation = GameScript.instance.playerToken.currPos;
        int stepsToMove = goToLocation - currLocation;
        if (stepsToMove > 0)
        {
            GameScript.instance.playerToken.move(stepsToMove);
        }
        else
        {
            GameScript.instance.playerToken.move(40 + stepsToMove);
        }
        GameScript.instance.chat.SendGameMessage("box and goes to " + locationName);
        GameScript.instance.chat.SendGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " opened a Treasure");
    }
}
