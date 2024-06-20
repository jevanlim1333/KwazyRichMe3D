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
    public int steps = 0;
    bool isMoving = false;

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

    public IEnumerator move()
    {
        if (isMoving)
        {
            Debug.Log("1");
            yield break;
        }
        Debug.Log("2");
        isMoving = true;

        while (steps > 0)
        {
            Debug.Log("3");
            Vector3 nextPos = thisRoute[currPos + 1];
            while (moveToNextTile(nextPos))
            {
                Debug.Log("4");
                yield return null;
            }
            Debug.Log("5");
            yield return new WaitForSeconds(0.1f);
            steps--;
            currPos++;
        }
        Debug.Log("6");
        isMoving = false;
    }

    bool moveToNextTile(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, 2f * Time.deltaTime));
    }

}
