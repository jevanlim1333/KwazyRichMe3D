using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;

public class GameScript : MonoBehaviour
{
    public static GameScript instance;
    public Route allRoutes;
    public List<Spawnpoints> spawnpoints;
    public List<string> tokenPrefabs;
    public List<GameObject> listOfTokens = new List<GameObject>();
    public DiceThrower dt1;
    public DiceThrower dt2;
    public int currPlayer = 0;
    public int dice1result;
    public int dice2result;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        int tokenNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        tokenPrefabs = new List<string>{"Token1", "Token2", "Token3", "Token4"};
        GameObject player = PhotonNetwork.Instantiate(tokenPrefabs[tokenNumber - 1], spawnpoints[tokenNumber - 1].GetComponent<Transform>().position, Quaternion.identity);
        player.GetComponent<Token>().setTokenNumber(tokenNumber);
        player.GetComponent<Token>().setRoutes(allRoutes);
        instance.listOfTokens.Add(player);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {

    }

    public void RollDice()
    {
        dt1.RollDice();
        dt2.RollDice();
        
        GameObject thisPlayer = listOfTokens[currPlayer];
        Debug.Log("GameScript calling Token.move");
        thisPlayer.GetComponent<Token>().move(dice1result + dice2result);
    }
}
