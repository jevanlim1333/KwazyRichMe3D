using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int tileNumber;
    float height = 10;
    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;
    public Vector3 p4;

    public float x1;
    public float z1;
    public float x2;
    public float z2;
    public float x3;
    public float z3;
    public float x4;
    public float z4;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void getPos()
    {
        p1 = new Vector3(x1, height, z1);
        p2 = new Vector3(x2, height, z2);
        p3 = new Vector3(x3, height, z3);
        p4 = new Vector3(x4, height, z4);
    }

    public void setPos()
    {
        if ((tileNumber >= 1 && tileNumber <= 9) || (tileNumber >= 21 && tileNumber <= 29))
        {
            x1 = transform.position.x; 
            x2 = transform.position.x; 
            x3 = transform.position.x; 
            x4 = transform.position.x; 
            z1 = transform.position.z + 72;
            z2 = transform.position.z + 24;
            z3 = transform.position.z - 24;
            z4 = transform.position.z - 72;
        }

        if ((tileNumber >= 11 && tileNumber <= 19) || (tileNumber >= 31 && tileNumber <= 39))
        {
            x1 = transform.position.x + 72;
            x2 = transform.position.x + 24;
            x3 = transform.position.x - 24;
            x4 = transform.position.x - 72;
            z1 = transform.position.z;
            z2 = transform.position.z;
            z3 = transform.position.z;
            z4 = transform.position.z;
        }

        if (tileNumber == 0 || tileNumber == 10 || tileNumber == 20 || tileNumber == 30)
        {
            x1 = transform.position.x + 50;
            x2 = transform.position.x + 50;
            x3 = transform.position.x - 50;
            x4 = transform.position.x - 50;
            z1 = transform.position.z + 50;
            z2 = transform.position.z - 50;
            z3 = transform.position.z + 50; 
            z4 = transform.position.z - 50;
        }
    }

}
