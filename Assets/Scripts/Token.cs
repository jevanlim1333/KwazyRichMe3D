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
    int currPos = 0;
    int tokenNumber;

    int boneScore;
 
    void Start()
    {
        //if (PhotonView.IsMine)
        {
            view = GetComponent<PhotonView>();
            transform.Rotate(0, 90, 0, Space.Self);
            bones = 6500;
            boneScore = 6500;
            Hashtable hash = new Hashtable();
            hash.Add("Bones", boneScore);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    void Update()
    {
        boneScore = (int)PhotonNetwork.LocalPlayer.CustomProperties["Bones"];
    
    }

    public void setTokenNumber(int i)
    {
        //if (PhotonView.IsMine) 
        {
            tokenNumber = i;
        }
        
    }

    public void setRoutes(Route r)
    {
        allRoutes = r;
        thisRoute = r.getRoute(tokenNumber);
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

            checkRotation();
            isMoving = false;
        }
        Debug.Log("moved");
    }

    public void checkRotation()
    {
        if (currPos == 0 || currPos == 10 || currPos == 20 || currPos == 30)
        {
            transform.Rotate(0, 90, 0, Space.Self);
        }
    }

}
