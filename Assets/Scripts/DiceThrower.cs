using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class DiceThrower : MonoBehaviour
{
    public dice diceToThrow;
    public int diceThrowerNumber;
    public float throwForce = 5f;   
    public float rollForce = 10f;

    private List<GameObject> _spawnedDice = new List<GameObject> ();

    private void Update()
    {
        
    }

    public void RollDice()
    {
        Debug.Log("Dice Thrower Roll Dice Called");
        if (diceToThrow == null) return;

        foreach (var die in _spawnedDice)
        {
            Destroy(die);
        }

        dice dice = Instantiate(diceToThrow, transform.position, transform.rotation);
        _spawnedDice.Add(dice.gameObject);
        dice.RollDice(throwForce, rollForce, diceThrowerNumber);

        Debug.Log("Dice Thrower Roll Dice End");
    }

}
