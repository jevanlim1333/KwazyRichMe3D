using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Tile[] tilesArray;
    public List<Vector3> route1 = new List<Vector3>();
    public List<Vector3> route2 = new List<Vector3>();
    public List<Vector3> route3 = new List<Vector3>();
    public List<Vector3> route4 = new List<Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Tile tile in tilesArray)
        {
            tile.setPos();
            tile.getPos();
            route1.Add(tile.p1);
            route2.Add(tile.p2);
            route3.Add(tile.p3);
            route4.Add(tile.p4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get the different routes 
    public List<Vector3> getRoute(int i)
    {
        if (i == 1)
        {
            return route1;
        }
        else if (i == 2)
        {
            return route2;
        }
        else if (i == 3)
        {
            return route3;
        }
        else 
        {
            return route4;
        }
    }
}
