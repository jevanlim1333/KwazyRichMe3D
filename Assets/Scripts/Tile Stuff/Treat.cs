using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : Tile
{
    public luckywheel luckywheelobject;
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
        luckywheelobject.openTreatsToSpin();
    }
}
