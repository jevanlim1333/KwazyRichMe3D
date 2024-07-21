using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
    /// </summary>
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
    public InputField playerNickname;
    public InputField createInput;
    public InputField joinInput;
    
    public void CreateRoom()
    {
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.NickName = playerNickname.text;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayersPerRoom;
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        // PhotonNetwork.CreateRoom(createInput.text);
        Debug.Log("Creating room, Load game scene");
        
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        Debug.Log("Joining room, Load game scene");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.NickName = playerNickname.text;
        PhotonNetwork.LoadLevel("Game");
        Debug.Log("Game Scene Loaded");
    }
}
