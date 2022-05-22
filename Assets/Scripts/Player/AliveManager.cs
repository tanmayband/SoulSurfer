using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UtilsClasses;

public class AliveManager : MonoBehaviour
{
    public TextMeshPro healthValueText;
    
    public RangedValue health;
    
    public AliveController aliveController;

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

    private void Death()
    {
        Debug.Log("Make ghost, BOOOO");
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

}
