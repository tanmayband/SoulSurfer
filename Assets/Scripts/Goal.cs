using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public TextMeshPro targetText;
    [SerializeField] int target;
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;
    
    SpriteRenderer spriteRenderer;
    Wallet playerWallet;
    
    [SerializeField]
    PlayerManager playerManager;

    bool isUnlocked;

    public event Action goalCompleteEvent;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        playerWallet = FindObjectOfType<Wallet>();
    }

    void Start()
    {
        targetText.text = target.ToString();
    }

    void Update()
    {
        //Check if player has enough coins to unlock the goal
        // if(playerWallet.GetCoins() >= target)
        // {
        //     isUnlocked = true;
        //     spriteRenderer.color = unlockColor;
        // }
        isUnlocked = playerManager.currentValue == target;
        spriteRenderer.color = isUnlocked ? unlockColor : defaultColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Complete the level if the player has enough coins
        if (other.GetComponent<Wallet>() == playerWallet)
        {
            if(isUnlocked) {
                goalCompleteEvent?.Invoke();
            }
        }
    }

    public void ClearEventHandlers()
    {
        goalCompleteEvent = null;
    }
}
