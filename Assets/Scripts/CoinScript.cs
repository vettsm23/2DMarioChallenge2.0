using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour

{
    AudioSource Pickup_Coin6;
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

            other.gameObject.SetActive(false);
        Pickup_Coin6.Play();
    }
    
 
}