using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class DiceThrower : MonoBehaviour
{
    public dice diceToThrow;
    public int amountOfDice = 2;
    public float throwForce = 5f;   
    public float rollForce = 10f;

    private List<GameObject> _spawnedDice = new List<GameObject> ();

    private void Update()
    {
        
    }

    public async void RollDice()
    {
        if (diceToThrow == null) return;

        foreach (var die in _spawnedDice)
        {
            Destroy(die);
        }

        for (int i = 0; i < amountOfDice; i++) 
        {
            dice dice = Instantiate(diceToThrow, transform.position, transform.rotation);
            _spawnedDice.Add(dice.gameObject);
            dice.RollDice(throwForce, rollForce, i);
            await Task.Yield();
        }
    }

}
