using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawnpoints : MonoBehaviour
{
    public GameObject playerPrefab;

    public float xcoord;
    public float ycoord;
    public float zcoord;
    public Material material;

    public void Start()
    {
        Vector3 pos = new Vector3(xcoord, ycoord, zcoord);
        GameObject token = PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
        Renderer rend = token.transform.Find("Body").gameObject.GetComponent<Renderer>();
        rend.material = material;
    }
}
