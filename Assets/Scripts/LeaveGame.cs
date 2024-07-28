using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LeaveGame : MonoBehaviour
{
    public Button leaveGameButton;
    public Button yesButton;
    public Button noButton;
    public Text areYouSureText;
    // Start is called before the first frame update
    void Start()
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        areYouSureText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendLeaveRoom()
    {
        GameScript.instance.chat.SendLeaveGameMessage("[GAME] " + PhotonNetwork.LocalPlayer.NickName + " has left the game.");
        GameScript.instance.GetComponent<PhotonView>().RPC("SomeoneLeftGame", RpcTarget.All);
        StartCoroutine(PauseBeforeLeaving());
    }

    public IEnumerator PauseBeforeLeaving()
    {
        yield return new WaitForSeconds(2f);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Launcher");
    }

    public void NoPressed()
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        leaveGameButton.gameObject.SetActive(true);
        areYouSureText.gameObject.SetActive(false);
    }

    public void LeaveGameButtonPressed()
    {
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        leaveGameButton.gameObject.SetActive(false);
        areYouSureText.gameObject.SetActive(true);
    }
}
