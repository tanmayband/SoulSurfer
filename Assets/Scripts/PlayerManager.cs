using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshPro valueText;
    public int currentValue;
    
    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        ChangeValue(currentValue);
    }

    public void ChangeValue(int newValue)
    {
        currentValue = newValue;
        valueText.text = currentValue.ToString();

        playerController.ToggleGhostMode(newValue == 0);
    }

    public void IncrementValue(int incrementBy)
    {
        ChangeValue(currentValue + incrementBy);
    }

    public void OnIncrease()
    {
        IncrementValue(5);
    }

    public void OnDecrease()
    {
        IncrementValue(-5);
    }

}
