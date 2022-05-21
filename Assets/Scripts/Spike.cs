using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        PlayerManager playerManager = other.GetComponent<PlayerManager>();
        if(playerManager != null)
        {
            playerManager.IncrementValue(-2);
        }    
    }
}
