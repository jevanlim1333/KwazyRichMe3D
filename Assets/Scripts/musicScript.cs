using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
   public static musicScript instance;

   private void Awake() 
   {
    if (instance == null)
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
   }
}
