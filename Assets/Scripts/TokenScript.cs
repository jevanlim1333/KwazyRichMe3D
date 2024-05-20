using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public string tokenName;
    public Tile position;
    public int bones;

    public List<Property> listOfProperties;

    public Token(string name) {
        this.tokenName = name;
        this.position = null;
        this.bones  = 5000;
    }
}
