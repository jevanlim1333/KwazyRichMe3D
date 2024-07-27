using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GoToScript : Card
{
    public int goToLocation;
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
    }
}
