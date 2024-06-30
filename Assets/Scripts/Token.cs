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
        transform.Rotate(0, 90, 0, Space.Self);
    }

    void Update()
    {

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
            transform.position = Vector3.MoveTowards(transform.position, nextPos, 50000f * Time.deltaTime);
            stepsToMove--;
            currPos++;
            checkRotation();
            isMoving = false;
        }
        Debug.Log("moved");
    }

    public void checkRotation()
    {
        if (currPos == 0)
        {
            transform.Rotate(0, 90, 0, Space.Self);
        }

        if (currPos == 10)
        {
            transform.Rotate(0, 180, 0, Space.Self);
        }

        if (currPos == 20)
        {
            transform.Rotate(0, -90, 0, Space.Self);
        }

        if (currPos == 30)
        {
            transform.Rotate(0, 0, 0, Space.Self);
        }
    }

}
