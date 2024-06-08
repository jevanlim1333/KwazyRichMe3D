using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawnpoints : MonoBehaviour
{
    public GameObject playerPrefab;

    public float xcoord;
    public float ycoord;
    public float zcoord;
    public Material material;

    public void Start()
    {
        
    }

    public void spawn(int i, Route allRoutes)
    {
        Vector3 pos = new Vector3(xcoord, ycoord, zcoord);
        GameObject token = PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
        Renderer rend = token.transform.Find("Body").gameObject.GetComponent<Renderer>();
        rend.material = material;
        token.GetComponent<Token>().setTokenNumber(i);
        token.GetComponent<Token>().setAllRoutes(allRoutes);
    }

}
