using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Token : MonoBehaviour
{
    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            // continue
        }
    }


}
