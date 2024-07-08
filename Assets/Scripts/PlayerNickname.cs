using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNickname : MonoBehaviour
{
    public Token playerToken;
    public string nickName = "Not Connected";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerToken == null)
        {
            TMP_Text tmp = GetComponent<TMP_Text>();
            tmp.text = nickName;
        }
        else 
        {
            TMP_Text tmp = GetComponent<TMP_Text>();
            tmp.text = playerToken.nickName + " - " + playerToken.bones;
        }
    }

    public void SetToken(Token token)
    {
        playerToken = token;
    }

}