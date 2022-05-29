using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UtilsClasses;

public class LevelButton : MonoBehaviour, IClassWithEvents
{
    public SceneReference level;
    public event System.Action<SceneReference> loadLevel;

    public void ButtonClick()
    {
        loadLevel?.Invoke(level);
    }

    public void ClearEventHandlers()
    {
        loadLevel = null;
    }
}
