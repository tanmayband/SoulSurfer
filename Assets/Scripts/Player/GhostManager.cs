using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public GhostController ghostController;

    public void ToggleGhostMode(bool enabled)
    {
        gameObject.SetActive(enabled);
        ghostController.isActive = enabled;
    }
}
