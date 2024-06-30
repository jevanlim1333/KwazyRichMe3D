using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody))]
public class dice : MonoBehaviour
{
    public Transform[] diceFaces;
    public Rigidbody rb;

    public int _diceIndex = -1;

    public bool _hasStoppedRolling;
    private bool _delayFinished;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

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

        return topFace + 1;
    }

    public async void RollDice(float throwForce, float rollForce, int i)
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

        while (!_hasStoppedRolling)
        {
            if (rb.velocity.sqrMagnitude == 0f) 
            {
                getResult();
            }
        }
        
        Debug.Log("Dice Roll Dice End");
    }

    private async void DelayResult()
    {
        await Task.Delay(1000);
        _delayFinished = true;
    }

    public void getResult()
    {
        if (_diceIndex == 1)
        {
            GameScript.instance.dice1result = GetNumberOnTopFace();
            Debug.Log("Dice 1 result " + GameScript.instance.dice1result);
        }
            
        if (_diceIndex == 2)
        {
            GameScript.instance.dice2result = GetNumberOnTopFace();
            Debug.Log("Dice 2 result " + GameScript.instance.dice2result);
        }
        _hasStoppedRolling = true;
    }
}

