using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class Token : MonoBehaviour
{
    PhotonView view;
    GameObject avatar;

    public Route allRoutes;
    public List<Vector3> thisRoute;

    int tokenNumber;
 
    void Start()
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

    public void setTokenNumber(int i)
    {
        tokenNumber = i;
    }

    public void setRoutes(Route r)
    {
        allRoutes = r;
        thisRoute = r.getRoute(tokenNumber);
    }

}
