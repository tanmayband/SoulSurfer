using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

using UtilsClasses;

public class PlayerManager : MonoBehaviour
{    
    public AliveManager aliveManager;
    public GhostManager ghostManager;
    private bool isGhost;

    void Awake()
    {
        
    }

    void Start()
    {
        aliveManager.ClearEventHandlers();
        aliveManager.DeathEvent += Death;

        if(aliveManager.health.current > 0) Revive();
        else Death();
    }

    private void Death()
    {
        Debug.Log("Become ghost BOOO");
        ghostManager.SpawnGhost(aliveManager.transform.position);
        aliveManager.ToggleAliveMode(false);
    }

    private void Revive()
    {
        Debug.Log("Become ALIVE");
        ghostManager.UnspawnGhost();
        aliveManager.ToggleAliveMode(true);
    }

    public void OnCHEATToggle(InputValue value)
    {
        Debug.Log("TOGGLIN' SIT TIGHT");
        isGhost = !isGhost;
        if(isGhost) Death();
        else Revive();
    }
}
