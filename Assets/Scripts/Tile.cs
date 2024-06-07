using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    float height = 50;
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
        p2 = new Vector3(x2, height, z1);
        p3 = new Vector3(x3, height, z3);
        p4 = new Vector3(x4, height, z4);
    }


}
