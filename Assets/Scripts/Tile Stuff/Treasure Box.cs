using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : Tile
{
    public TreasureBoxCanvas treasureBoxCanvas;

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
        Debug.Log("Treasure Box Tile Action");
        treasureBoxCanvas.SelectCard();
        //TileManager.instance.FinishedTileAction();
    }
}
