using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    public Transform[] diceFaces;
    public Rigidbody rb;

    public int _diceIndex = -1;

    private bool _hasStoppedRolling;
    private bool _delayFinished;

    PhotonView view;

    void Start() 
    {
        view = GetComponent<PhotonView>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_delayFinished) return;
        
        if (!_hasStoppedRolling && rb.velocity.sqrMagnitude == 0f)
        {
            _hasStoppedRolling = true;
            if (_diceIndex == 1)
            {
                GameScript.instance.dice1result = GetNumberOnTopFace();
                GameScript.instance.dice1move = true;
            }
            if (_diceIndex == 2)
            {
                GameScript.instance.dice2result = GetNumberOnTopFace();
                GameScript.instance.dice2move = true;
            }
        }
    }

    [ContextMenu("Get Top Face")]
    private int GetNumberOnTopFace()
    {
        if (diceFaces == null) return -1;

        var topFace = 0;

        var lastYPosition = diceFaces[0].position.y;

        for (int i = 0; i < diceFaces.Length; i++) 
        {
            if (diceFaces[i].position.y > lastYPosition) 
            {
                lastYPosition = diceFaces[i].position.y;
                topFace = i;
            }
        }

        int result = topFace + 1;
        Debug.Log("Dice " + _diceIndex + " rolled " + result);

        return topFace + 1;

    }

    public void RollDice(float throwForce, float rollForce, int i)
    {
        Debug.Log("Dice Roll Dice Called");
        _diceIndex = i;
        var randomVariance = Random.Range(-10000f, 10000f);
        rb.AddForce(-transform.up * (throwForce + randomVariance), ForceMode.Impulse);

        var randX = Random.Range(0f, 1f);
        var randY = Random.Range(0f, 1f);
        var randZ = Random.Range(0f, 1f);

        rb.AddTorque(new Vector3(randX, randY, randZ) * (rollForce + randomVariance), ForceMode.Impulse);

        DelayResult();
        Debug.Log("Dice Roll Dice End");
    }

    private async void DelayResult()
    {
        await Task.Delay(1000);
        _delayFinished = true;
    }
}

