using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        AliveManager aliveManager = other.GetComponent<AliveManager>();
        if(aliveManager != null)
        {
            aliveManager.Kill();
        }    
    }
}
