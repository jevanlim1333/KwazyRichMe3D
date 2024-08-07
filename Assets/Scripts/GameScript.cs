using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
    public luckywheel luckyWheel;
    public bool lostGame = false;
    public Text lostGameText;
    public TMP_Text roomName;
    public bool gameEnded;
    public Scoreboard scoreboard;
    public Canvas winnerCanvas;
    public LeaveGame leaveGame;
    
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
        roomName.text = "ROOM NAME: " + PhotonNetwork.CurrentRoom.Name;
        lostGameText.enabled = false;
        int tokenNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        playerGameObject = PhotonNetwork.Instantiate(tokenPrefabs[tokenNumber - 1], spawnpoints[tokenNumber - 1].GetComponent<Transform>().position, Quaternion.identity);
        playerToken = playerGameObject.GetComponent<Token>();
        playerToken.setUpToken(tokenNumber, allRoutes);
    }
    // Update is called once per frame
    void Update()
    {
        checkRotation();

        if (gameEnded)
        {
            rollDiceButton.interactable = false;
        }

        if (lostGame)
        {
            lostGameText.enabled = true;
        }
        if (currPlayer == PhotonNetwork.LocalPlayer.ActorNumber && rolling == false && gameEnded == false)
        {
            CurrentPlayerRPC.instance.SendCurrentPlayerInfo();
            if (lostGame)
            {
                SetNextPlayer();
            }
            else if (NapTime.instance.numberOfRoundsSkip > 0) // token nap time
            {
                NapTime.instance.TileAction();
            }
            else // not nap time
            {  
                rollDiceButton.interactable = true;
            }
        }
        else
        {
            rollDiceButton.interactable = false;
        }

        if ((currPlayer == PhotonNetwork.LocalPlayer.ActorNumber) && (dice1move && dice2move))
        {
            Debug.Log("GameScript calling Token.move");
            int stepsToMove = dice1result + dice2result;
            chat.SendGameMessage("[GAME] " + playerGameObject.GetComponent<Token>().nickName + " rolled " + stepsToMove);
            dice1move = false;
            dice2move = false;
            StartCoroutine(dt1.destroy());
            StartCoroutine(dt2.destroy());
            playerGameObject.GetComponent<Token>().move(stepsToMove);
            Debug.Log("GameScript Roll Dice End");
        }
    }

    public void RollDice()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        scoreboard.GetComponent<PhotonView>().RPC("SetUpWinnerCounter", RpcTarget.All);

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

    [PunRPC]
    public void SomeoneLeftGame()
    {
        gameEnded = true;
    }

    public void IWon()
    {
        GetComponent<PhotonView>().RPC("SomeoneWon", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName);
    }

    [PunRPC]
    public void SomeoneWon(string name)
    {
        winnerCanvas.transform.Find("Winner Text").GetComponent<TMP_Text>().text = "" + name + " has won the game!";
        winnerCanvas.gameObject.SetActive(true);
        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10f);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Launcher");
    }
}
