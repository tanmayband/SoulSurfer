using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class AliveController : MonoBehaviour
{
    public SpriteRenderer body;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] Collider2D feet;

    public bool isActive {get; private set;}
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2f;
    public ParticleSystem possessRings;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    bool jumpPressed;
    public Rigidbody2D rb;
    public BoxCollider2D collision;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource possessSound;


    const string platformLayer = "Platform";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        TogglePossessVFX(false);
    }

    void FixedUpdate()
    {
        if(isActive)
        {
            //Move the player
            rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);

            //Make the player jump
            if (isJumping)
            {
                rb.velocity += Vector2.up * jumpForce;
                isJumping = false;
                jumpSound.Play();
            }

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
        rawInput = value.Get<Vector2>();

        if (!isActive) { return; }
        
        jumpPressed = rawInput.y > 0;
        isJumping = (
            jumpPressed
            && feet.IsTouchingLayers(LayerMask.GetMask(platformLayer))
        );
    }

    public void ToggleActive(bool active)
    {
        isActive = active;
        rb.velocity = isActive ? rb.velocity : Vector2.zero;
    }

    public void ClearEventHandlers()
    {

    }

    public void SetBodyColour(Color newColour)
    {
        body.color = newColour;
    }

    public void TogglePossessVFX(bool active)
    {
        possessRings.gameObject.SetActive(active);
    }
}
