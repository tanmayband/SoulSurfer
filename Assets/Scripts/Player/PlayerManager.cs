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

    void Awake()
    {
        
    }

    void Start()
    {
        aliveManager.ClearEventHandlers();
        aliveManager.DeathEvent += Death;
    }

    private void Death()
    {
        Debug.Log("Become ghost BOOO");
        ghostManager.ToggleGhostMode(true);
        aliveManager.ToggleAliveMode(false);
    }

    private void Revive()
    {
        Debug.Log("Become ALIVE");
        ghostManager.ToggleGhostMode(false);
        aliveManager.ToggleAliveMode(true);
    }

    public void OnToggle(InputValue value)
    {
        
    }
}
