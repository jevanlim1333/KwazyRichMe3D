using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : Tile
{
    public List<Card> listOfCards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TileAction()
    {
        TileManager.instance.FinishedTileAction();
    }
}