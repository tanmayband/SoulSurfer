using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Constants;

public class Goal : MonoBehaviour
{
    public event Action goalCompleteEvent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (ConstantsUtils.CheckLayer(other.gameObject.layer, LAYER.Character))
        // if(other.name == "AliveMC")
        {
            goalCompleteEvent?.Invoke();
        }
    }

    public void ClearEventHandlers()
    {
        goalCompleteEvent = null;
    }
}
