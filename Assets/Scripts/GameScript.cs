using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GameScript : MonoBehaviourPunCallbacks
{
    public static GameScript instance;
    public Route allRoutes;
    public List<Spawnpoints> spawnpoints;
    public List<string> tokenPrefabs = new List<string>{"Token1", "Token2", "Token3", "Token4"};
    public List<GameObject> listOfTokens;
    public DiceThrower dt1;
    public DiceThrower dt2;
    public int dice1result;
    public int dice2result;
    public bool dice1move;
    public bool dice2move;
    public int currPlayer = 0;
    public Chat chat;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }

        if (PhotonNetwork.IsMasterClient) //condition added
        {
            List<GameObject> listOfTokens = new List<GameObject>(); 
        }

        int tokenNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        GameObject player = PhotonNetwork.Instantiate(tokenPrefabs[tokenNumber - 1], spawnpoints[tokenNumber - 1].GetComponent<Transform>().position, Quaternion.identity);
        Token playerToken = player.GetComponent<Token>();
        playerToken.setUpToken(tokenNumber, allRoutes);
        listOfTokens.Add(player);

        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties);
    }
    // Update is called once per frame
    void Update()
    {

        if (dice1move && dice2move)
        { 
            GameObject thisPlayer = listOfTokens[currPlayer];
            Debug.Log("GameScript calling Token.move");
            int stepsToMove = dice1result + dice2result;
            thisPlayer.GetComponent<Token>().move(stepsToMove);
            Debug.Log("GameScript Roll Dice End");
            dice1move = false;
            dice2move = false;
            StartCoroutine(dt1.destroy());
            StartCoroutine(dt2.destroy());
            chat.GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, ("[GAME] " + thisPlayer.GetComponent<Token>().nickName + " rolled " + stepsToMove ));
            //chat.GetMessage("[GAME] " + thisPlayer.GetComponent<Token>().nickName + " rolled " + stepsToMove);
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
