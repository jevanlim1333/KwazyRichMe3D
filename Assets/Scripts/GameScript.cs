using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using UnityEngine.UI;

public class GameScript : MonoBehaviourPunCallbacks
{
    public static GameScript instance;
    public Route allRoutes;
    public List<Spawnpoints> spawnpoints;
    public List<string> tokenPrefabs = new List<string>{"Token1", "Token2", "Token3", "Token4"};
    public DiceThrower dt1;
    public DiceThrower dt2;
    public int dice1result;
    public int dice2result;
    public bool dice1move;
    public bool dice2move;
    public int currPlayer = 1;
    public Chat chat;
    public GameObject playerGameObject;
    public Token playerToken;
    public Button rollDiceButton;
    public bool rolling = false;

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

        int tokenNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        playerGameObject = PhotonNetwork.Instantiate(tokenPrefabs[tokenNumber - 1], spawnpoints[tokenNumber - 1].GetComponent<Transform>().position, Quaternion.identity);
        playerToken = playerGameObject.GetComponent<Token>();
        playerToken.setUpToken(tokenNumber, allRoutes);
    }
    // Update is called once per frame
    void Update()
    {
        checkRotation();
        if (currPlayer == PhotonNetwork.LocalPlayer.ActorNumber && rolling == false)
        {
            rollDiceButton.interactable = true;
        }
        else
        {
            rollDiceButton.interactable = false;
        }

        if ((currPlayer == PhotonNetwork.LocalPlayer.ActorNumber) && (dice1move && dice2move))
        {
            Debug.Log("GameScript calling Token.move");
            int stepsToMove = dice1result + dice2result;
            playerGameObject.GetComponent<Token>().move(stepsToMove);
            Debug.Log("GameScript Roll Dice End");
            dice1move = false;
            dice2move = false;
            StartCoroutine(dt1.destroy());
            StartCoroutine(dt2.destroy());
            chat.GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, ("[GAME] " + playerGameObject.GetComponent<Token>().nickName + " rolled " + stepsToMove ));
            GetComponent<PhotonView>().RPC("SetNextPlayer", RpcTarget.All);
        }
    }

    public void RollDice()
    {
        GetComponent<PhotonView>().RPC("SetRolling", RpcTarget.All, true);
        Debug.Log("GameScript Roll Dice Called");
        dt1.RollDice();
        dt2.RollDice();
    }

    public void checkRotation()
    {
        int gameObjectPos = playerGameObject.GetComponent<Token>().currPos;
        if (gameObjectPos >= 0 && gameObjectPos <= 9)
        {
            playerGameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (gameObjectPos >= 10 && gameObjectPos <= 19)
        {
            playerGameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (gameObjectPos >= 20 && gameObjectPos <= 29)
        {
            playerGameObject.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (gameObjectPos >= 30 && gameObjectPos <= 39)
        {
            playerGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    [PunRPC]
    public void SetNextPlayer()
    {
        if (currPlayer == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            currPlayer = 1;
            Debug.Log("Moving back to Player 1");
        }
        else 
        {
            currPlayer++;
            Debug.Log("Moving to next player");
        }
    }

    [PunRPC]
    public void SetRolling(bool boolean)
    {
        rolling = boolean;
    }
}
