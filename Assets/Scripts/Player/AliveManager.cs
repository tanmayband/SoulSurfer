using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UtilsClasses;

public class AliveManager : MonoBehaviour, IClassWithEvents
{
    public TextMeshPro healthValueText;
    
    public RangedValue health;
    
    public AliveController aliveController;

    public event Action DeathEvent;

    void Awake()
    {
        aliveController = GetComponent<AliveController>();
    }

    void Start()
    {
        health = new RangedValue(0, 10, 10);
        health.ClearEventHandlers();
        health.MinReachedEvent += Death;

        SetHealth(health.current);
    }

    public void SetHealth(float newHealth)
    {
        health.SetValue(newHealth);
        healthValueText.text = health.current.ToString();
    }

    public void IncrementHealth(int incrementBy)
    {
        SetHealth(health.current + incrementBy);
    }

    public void Kill()
    {
        SetHealth(health.min);
    }

    private void Death()
    {
        aliveController.SetBodyColour(new Color(0.2f,0.2f,0.2f));
        DeathEvent?.Invoke();
        aliveController.deathSound.Play();
    }

    public void ClearEventHandlers()
    {
        DeathEvent = null;
    }

    public void ToggleAliveMode(bool enabled)
    {
        aliveController.ToggleActive(enabled);
    }

    public bool IsAlive()
    {
        return health.current > health.min;
    }

}
