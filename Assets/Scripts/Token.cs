using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Token : MonoBehaviour
{
    PhotonView view;
<<<<<<< Updated upstream
    int tokenNumber;
=======
    public string nickName;
    public int bones;
>>>>>>> Stashed changes
    public Route allRoutes;
    public List<Vector3> thisRoute;

    private void Start()
    {
        view = GetComponent<PhotonView>();
<<<<<<< Updated upstream
        thisRoute = allRoutes.getRoute(tokenNumber);
=======
        transform.Rotate(0, 90, 0, Space.Self);
        bones = 6500;
>>>>>>> Stashed changes
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
