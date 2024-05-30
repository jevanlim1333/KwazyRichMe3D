using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public List<Spawnpoints> spawnpoints;
    public List<Token> listOfTokens;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < spawnpoints.Count; i++)
        {
            spawnpoints[i].spawn();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
