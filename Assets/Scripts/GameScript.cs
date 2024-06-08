using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public Route allRoutes;
    public List<Spawnpoints> spawnpoints;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < spawnpoints.Count; i++)
        {
            spawnpoints[i].spawn(i + 1, allRoutes);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
