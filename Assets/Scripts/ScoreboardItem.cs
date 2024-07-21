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
    }

    void Update()
    {

    }
}
