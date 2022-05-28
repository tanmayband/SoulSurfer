using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UtilsClasses;

public class GhostController : MonoBehaviour, IClassWithEvents
{
    public SpriteRenderer body;
    [SerializeField] float moveSpeed = 6f;
    public bool isActive {get; private set;}

    Vector2 rawInput;
    public Rigidbody2D rb;
    public BoxCollider2D collision;
    public event Action<AliveManager> PossessingEvent;
    public AudioSource overlapSound;

    private AliveManager overlappingCharacter;
    private Shaker shaker;
    private float overlappingCharacterDistance;
    private SteppedRange distanceRange;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        shaker = GetComponent<Shaker>();
        rb.gravityScale = 0;

        distanceRange = new SteppedRange(new List<float>{0, 0.5f, 1f, 1.5f, 2f});
    }

    void FixedUpdate()
    {
        if(isActive)
        {
            //Move the player
            rb.velocity = new Vector2(rawInput.x * moveSpeed, rawInput.y * moveSpeed);

            if(overlappingCharacter != null && overlappingCharacter.IsAlive())
            {
                float newDistance = Vector2.Distance(overlappingCharacter.transform.position, shaker.center.position);
                ProcessDistance(newDistance);
            };
        }
    }

    public void ToggleActive(bool active)
    {
        isActive = active;
        rb.velocity = isActive ? rb.velocity : Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<AliveManager>() != null)
        {
            overlappingCharacter = other.GetComponent<AliveManager>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<AliveManager>() != null)
        {
            overlappingCharacter.aliveController.TogglePossessVFX(false);
            overlappingCharacter = null;
            shaker.StopShake();
            overlapSound.Stop();
        }
    } 

    public void ClearEventHandlers()
    {
        PossessingEvent = null;
    }

    private void ProcessDistance(float newDistance)
    {
        newDistance = (float)Math.Round(newDistance,2);
        if(distanceRange.WithinRange(newDistance))
        {
            newDistance = distanceRange.GetSteppedValue(newDistance);
            if(newDistance != overlappingCharacterDistance)
            {
                overlappingCharacterDistance = newDistance;
                if(overlappingCharacterDistance < 1)
                {
                    PossessCharacter();
                }
                else
                {
                    List<int> vibrations = new List<int>{20, 20, 20, 5, 5};
                    shaker.ShakeThatThing(vibrations[distanceRange.stepRangeValues.IndexOf(overlappingCharacterDistance)]);
                    overlappingCharacter.aliveController.TogglePossessVFX(true);
                    if(!overlapSound.isPlaying)
                    {
                        overlapSound.Play();
                    }
                }

            }
        }
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
            PossessCharacter();
        }

    #endregion

    private void PossessCharacter()
    {
        shaker.StopShake();
        PossessingEvent?.Invoke(overlappingCharacter);
        overlappingCharacter = null;
    }
}
