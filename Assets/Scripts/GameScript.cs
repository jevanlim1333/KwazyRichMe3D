using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameScript : MonoBehaviour
{
    public static GameScript instance;
    public Route allRoutes;
    public List<Spawnpoints> spawnpoints;
    public Material[] materials;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        int tokenNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("this tokenNumber is " + tokenNumber);
        GameObject player = PhotonNetwork.Instantiate("Token", spawnpoints[tokenNumber - 1].GetComponent<Transform>().position, Quaternion.identity);
        player.transform.Find("Body").gameObject.GetComponent<Renderer>().material = materials[tokenNumber - 1];
        player.GetComponent<Token>().setTokenNumber(tokenNumber);
        player.GetComponent<Token>().setRoutes(allRoutes);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {

    }
}
