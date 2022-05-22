using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : AliveManager
{
    // Start is called before the first frame update
    void Start()
    {
        aliveController.ToggleActive(false);
    }



}
