using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void Awake()
    {
        gameObject.layer = 8;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Add the coin to the player wallet when collectd
        // Wallet wallet = other.GetComponent<Wallet>();
        // if(wallet != null)
        // {
        //     wallet.IncrementCoins();
        //     Destroy(gameObject);
        // }
        AliveManager aliveManager = other.GetComponent<AliveManager>();
        if(aliveManager != null)
        {
            aliveManager.IncrementHealth(10);
            Destroy(gameObject);
        }
    }
}
