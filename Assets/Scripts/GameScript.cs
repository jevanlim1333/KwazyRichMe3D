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
    public int dice1result;
    public int dice2result;
    public bool dice1move;
    public bool dice2move;
    public int currPlayer = 0;
    public BonesCounter bonesCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        int tokenNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        tokenPrefabs = new List<string>{"Token1", "Token2", "Token3", "Token4"};
        GameObject player = PhotonNetwork.Instantiate(tokenPrefabs[tokenNumber - 1], spawnpoints[tokenNumber - 1].GetComponent<Transform>().position, Quaternion.identity);
        Token playerToken = player.GetComponent<Token>();
        playerToken.setTokenNumber(tokenNumber);
        playerToken.setRoutes(allRoutes);
        playerToken.nickName = PhotonNetwork.NickName;
        instance.listOfTokens.Add(player);
        bonesCounter.setToken(tokenNumber, playerToken);
    }

    // Update is called once per frame
    void Update()
    {
        if (dice1move && dice2move)
        { 
            GameObject thisPlayer = listOfTokens[currPlayer];
            Debug.Log("GameScript calling Token.move");
            thisPlayer.GetComponent<Token>().move(dice1result + dice2result);
            Debug.Log("GameScript Roll Dice End");
            dice1move = false;
            dice2move = false;
        }
    }

    void Awake()
    {

    }

    public void RollDice()
    {
        Debug.Log("GameScript Roll Dice Called");
        dt1.RollDice();
        dt2.RollDice();
    }
}
