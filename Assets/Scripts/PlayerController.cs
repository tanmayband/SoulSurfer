using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] Collider2D feet;

    public bool isActive = true;
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2f;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    bool jumpPressed;
    public Rigidbody2D rb;
    public BoxCollider2D collision;


    const string platformLayer = "Platform";

    private bool isGhost;
    public event Action restartLevelEvent;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        //Move the player
        rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);

        //Make the player jump
        if (isJumping)
        {
            if(isGhost)
            {
                rb.velocity += Vector2.up * moveSpeed;
            }
            else
            {
                rb.velocity += Vector2.up * jumpForce;
            }
            isJumping = false;
        }

        if(!isGhost)
        {
            // make the jump better
            if(rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if(rb.velocity.y > 0 && !jumpPressed)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    //Used by the input system 
    void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        rawInput = value.Get<Vector2>();
    }

    //Used by the input system
    void OnJump(InputValue value)
    {
        if (!isActive) { return; }
        jumpPressed = value.isPressed;
        if (!feet.IsTouchingLayers(LayerMask.GetMask(platformLayer))) { return; }
        
        isJumping = true;
    }

    void OnRestart()
    {
        restartLevelEvent?.Invoke();
    }

    public void ClearEventHandlers()
    {
        restartLevelEvent = null;
    }
    
    public void ToggleGhostMode(bool enabled)
    {
        isGhost = enabled;
        collision.enabled = !enabled;
        rb.gravityScale = enabled ? 0 : 1;
    }
}
