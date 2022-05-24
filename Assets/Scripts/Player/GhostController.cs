using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UtilsClasses;

public class GhostController : MonoBehaviour, IClassWithEvents
{
    
    [SerializeField] float moveSpeed = 6f;
    public bool isActive {get; private set;}

    Vector2 rawInput;
    public Rigidbody2D rb;
    public BoxCollider2D collision;
    public event Action<AliveManager> PossessingEvent;

    private AliveManager overlappingCharacter;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if(isActive)
        {
            //Move the player
            rb.velocity = new Vector2(rawInput.x * moveSpeed, rawInput.y * moveSpeed);
        }
    }

    public void ToggleActive(bool active)
    {
        isActive = active;
        rb.velocity = isActive ? rb.velocity : Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.GetComponent<AliveManager>() != null)
        {
            overlappingCharacter = other.GetComponent<AliveManager>();
        }
    }

    public void ClearEventHandlers()
    {
        PossessingEvent = null;
    }

    #region INPUT
    //Used by the input system

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        if (!isActive) { return; }
    }

    void OnPossess(InputValue value)
    {
        PossessingEvent?.Invoke(overlappingCharacter);
    }

    #endregion
    
}
