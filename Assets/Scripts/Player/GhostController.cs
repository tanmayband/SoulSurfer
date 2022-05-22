using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    public bool isActive {get; private set;}

    Vector2 rawInput;
    public Rigidbody2D rb;
    public BoxCollider2D collision;

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

    //Used by the input system 
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        if (!isActive) { return; }
    }

    public void ToggleActive(bool active)
    {
        isActive = active;
        rb.velocity = isActive ? rb.velocity : Vector2.zero;
    }
}
