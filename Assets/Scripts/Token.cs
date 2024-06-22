using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class Token : MonoBehaviour
{
    PhotonView view;

    public Route allRoutes;
    public List<Vector3> thisRoute;
    int currPos = 0;
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

    public void move(int steps)
    {
        Debug.Log("start of move");
        int stepsToMove = steps;
        Debug.Log("stepsToMove = " + steps);
        bool isMoving = false;
        while (stepsToMove > 0 && isMoving == false)
        {
            isMoving = true;
            Vector3 nextPos = thisRoute[currPos + 1];
            Debug.Log("moving from " + transform.position + "to " + nextPos);
            transform.position = Vector3.MoveTowards(transform.position, nextPos, 20000f * Time.deltaTime);
            stepsToMove--;
            currPos++;
            isMoving = false;
        }
        Debug.Log("moved");
    }

}
