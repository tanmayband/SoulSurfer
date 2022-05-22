using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public GhostController ghostController { get; private set; }

    void Awake()
    {
        ghostController = GetComponent<GhostController>();
    }

    private void ToggleGhostMode(bool enabled)
    {
        gameObject.SetActive(enabled);
        ghostController.ToggleActive(enabled);
    }

    public void SpawnGhost(Vector2 spawnPosition)
    {
        transform.position = spawnPosition;
        ToggleGhostMode(true);
    }

    public void UnspawnGhost()
    {
        ToggleGhostMode(false);
    }
}
