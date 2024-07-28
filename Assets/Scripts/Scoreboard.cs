using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;
    Dictionary<Player, ScoreboardItem> scoreboardItems = new Dictionary<Player, ScoreboardItem>();
    public List<bool> WinnerCounter;
    public bool WinnerCounterSetUp;
    void Start()
    {
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            AddScoreboardItem(player);
        }
    }

    void Update()
    {
        int MyBones = GameScript.instance.playerToken.bones;
        if (WinnerCounterSetUp && MyBones <= 0)
        {
            GetComponent<PhotonView>().RPC("ChangeWinnerCounter", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, false);
        }
        
        if (WinnerCounterSetUp && MyBones > 0)
        {
            GetComponent<PhotonView>().RPC("ChangeWinnerCounter", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, true);
        }
        GetComponent<PhotonView>().RPC("ChangeScoreboardValue", RpcTarget.All, PhotonNetwork.LocalPlayer, MyBones);

        if (WinnerCounterSetUp)
        {
            bool IWin = true;
            for (int i = 0; i < WinnerCounter.Count; i++)
            {
                if (i == PhotonNetwork.LocalPlayer.ActorNumber - 1)
                {
                    IWin = IWin && WinnerCounter[i];
                }
                else
                {
                    IWin = IWin && !WinnerCounter[i];
                }
            }

            if (IWin)
            {
                GameScript.instance.IWon();
            }
        }
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreboardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player oldPlayer)
    {
        RemoveScoreboardItem(oldPlayer);
    }

    void AddScoreboardItem(Player player)
    {
        ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
        item.Initialize(player);
        scoreboardItems[player] = item;
    }

    void RemoveScoreboardItem(Player player)
    {
        Destroy(scoreboardItems[player].gameObject);
        scoreboardItems.Remove(player);
    }

    [PunRPC]
    public void ChangeScoreboardValue(Player player, int bones)
    {
        scoreboardItems[player].bonesText.text = "" + bones;
    }

    [PunRPC]
    public void SetUpWinnerCounter()
    {
        if (!WinnerCounterSetUp)
        {
            WinnerCounter = new List<bool>();
            for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
            {
                WinnerCounter.Add(true);
            }
        }
        WinnerCounterSetUp = true;
    }

    [PunRPC]
    public void ChangeWinnerCounter(int actorNumber, bool inGame)
    {
        WinnerCounter[actorNumber - 1] = inGame;
    }
}
