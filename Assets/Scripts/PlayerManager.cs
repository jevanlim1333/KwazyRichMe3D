using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using System.Collections;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public int bones = 6500;
    public static GameObject LocalPlayerInstance;
    [SerializeField]
     public GameObject PlayerUiPrefab;

    #region IPunObservable implementation

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(bones);
        }
        else
        {
            // Network player, receive data
            this.bones = (int)stream.ReceiveNext();
        }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerUiPrefab != null)
        {
            GameObject _uiGo =  Instantiate(PlayerUiPrefab);
            _uiGo.SendMessage ("SetTarget", this, SendMessageOptions.RequireReceiver);
        }
        else
        {
            Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (bones <= 0)
            {
                GameScript.instance.LeaveRoom();
            }
        
        }
    }

    void Awake()
    {
        // #Important
        // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
        if (photonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
         }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
    }
}
