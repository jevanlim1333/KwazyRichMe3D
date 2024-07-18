using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class ScoreboardItem : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text bonesText;
    public Token token;
    public void Initialize(Player player)
    {
        usernameText.text = player.NickName;
        token = GameScript.instance.listOfTokens[player.ActorNumber - 1].GetComponent<Token>();
    
    }

    void Update()
    {
        bonesText.text = "" + token.bones;
    }
}
