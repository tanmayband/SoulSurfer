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

        ghostManager.ghostController.ClearEventHandlers();
        ghostManager.ghostController.PossessingEvent += ChangeBody;

        if(aliveManager.health.current > 0) Revive();
        else Death();
    }

    private void Death()
    {
        ghostManager.SpawnGhost(aliveManager.transform.position);
        aliveManager.ToggleAliveMode(false);
    }

    private void ChangeBody(AliveManager newBodyManager)
    {
        if(newBodyManager.IsAlive())
        {
            aliveManager.ClearEventHandlers();
            aliveManager = newBodyManager;
            aliveManager.DeathEvent += Death;
            Revive();
            aliveManager.aliveController.possessSound.Play();
        }
    }

    private void Revive()
    {
        ghostManager.UnspawnGhost();
        aliveManager.ToggleAliveMode(true);
    }

    public void OnPause()
    {
        PauseMenu.instance.TogglePauseMenu();
    }

    public void OnCHEATToggle(InputValue value)
    {
        Debug.Log("TOGGLIN' SIT TIGHT");
        Death();

        // isGhost = !isGhost;
        // if(isGhost) Death();
        // else Revive();
    }
}
