using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
   public static musicScript instance;

   [SerializeField] AudioSource musicSource;
   public AudioClip background;

   private void Start()
   {
    musicSource.clip = background;
    musicSource.Play();
   }

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
