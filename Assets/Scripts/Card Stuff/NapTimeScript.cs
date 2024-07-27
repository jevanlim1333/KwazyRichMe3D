using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameScript.instance.playerToken.currPos = 20;
        GameScript.instance.allRoutes.tilesArray[20].TileAction();
    }
}
