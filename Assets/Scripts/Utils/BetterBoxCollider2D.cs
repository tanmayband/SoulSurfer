using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UtilsClasses;

[RequireComponent(typeof(BoxCollider2D))]
public class BetterBoxCollider2D : MonoBehaviour, IClassWithEvents
{
    private BoxCollider2D boxCollider;
    public event Action<Collider2D> OnTriggerEnterEvent;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnterEvent?.Invoke(other);
    }

    public void ClearEventHandlers()
    {
        OnTriggerEnterEvent = null;
    }
}
