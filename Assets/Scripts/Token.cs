using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Token : MonoBehaviour
{
    PhotonView view;
    int tokenNumber;
    public Route allRoutes;
    public List<Vector3> thisRoute;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        thisRoute = allRoutes.getRoute(tokenNumber);
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

    public void setAllRoutes(Route r)
    {
        allRoutes = r;
    }

}
