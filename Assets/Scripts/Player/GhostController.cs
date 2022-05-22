using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    public bool isActive = true;

    Vector2 rawInput;
    public Rigidbody2D rb;
    public BoxCollider2D collision;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(rawInput.x * moveSpeed, rawInput.y * moveSpeed);
    }

    //Used by the input system 
    void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        rawInput = value.Get<Vector2>();
    }
}
