using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Token : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public Route allRoutes;
    public List<Vector3> thisRoute;
    public int bones;
    public string nickName;
    public int currPos = 0;
    public int tokenNumber;
 
    void Start()
    {
        view = GetComponent<PhotonView>();
        bones = 6500;
    }

    void Update()
    {

    }

    public void setUpToken(int tokenNumber1, Route route)
    {
        tokenNumber = tokenNumber1;
        allRoutes = route;
        thisRoute = route.getRoute(tokenNumber);
        nickName = PhotonNetwork.NickName;
    }

    public void move(int steps)
    {
        Debug.Log("start of move");
        int stepsToMove = steps;
        Debug.Log("stepsToMove = " + steps);
        bool isMoving = false;
        while (stepsToMove > 0 && isMoving == false)
        {
            isMoving = true;
            Vector3 nextPos;

            if (currPos == 39)
            {
                nextPos = thisRoute[0];
            }
            else {
                nextPos = thisRoute[currPos + 1];
            }

            Debug.Log("moving from " + transform.position + "to " + nextPos);
            transform.position = Vector3.MoveTowards(transform.position, nextPos, 750000f * Time.deltaTime);
            stepsToMove--;

            if (currPos == 39)
            {
                currPos = 0;
            }
            else {
                currPos++;
            }

            isMoving = false;
        }
        Debug.Log("moved");
        GameScript.instance.allRoutes.tilesArray[currPos].TileAction();
    }

}
