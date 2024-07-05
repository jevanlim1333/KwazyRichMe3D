using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public Route allRoutes;
    public List<Spawnpoints> spawnpoints;
<<<<<<< Updated upstream
=======
    public List<string> tokenPrefabs;
    public List<GameObject> listOfTokens = new List<GameObject>();
    public DiceThrower dt1;
    public DiceThrower dt2;
    public int dice1result;
    public int dice2result;
    public int currPlayer = 0;
    public BonesCounter bonesCounter;
>>>>>>> Stashed changes
    
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        for (var i = 0; i < spawnpoints.Count; i++)
        {
            spawnpoints[i].spawn(i + 1, allRoutes);
        }

=======
        instance = this;
        int tokenNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        tokenPrefabs = new List<string>{"Token1", "Token2", "Token3", "Token4"};
        GameObject player = PhotonNetwork.Instantiate(tokenPrefabs[tokenNumber - 1], spawnpoints[tokenNumber - 1].GetComponent<Transform>().position, Quaternion.identity);
        Token playerToken = player.GetComponent<Token>();
        playerToken.setTokenNumber(tokenNumber);
        playerToken.setRoutes(allRoutes);
        playerToken.nickName = PhotonNetwork.NickName;
        bonesCounter.setToken(tokenNumber, playerToken);
        instance.listOfTokens.Add(player);
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
