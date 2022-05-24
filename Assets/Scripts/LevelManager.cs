using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // public string nextLevel;
    public SceneReference nextLevel;
    public PlayerManager playerManager;
    public Goal goal;

    void Start()
    {
        goal.ClearEventHandlers();
        goal.goalCompleteEvent += GoToNextLevel;
    }

    public void GoToNextLevel()
    {
        if(!string.IsNullOrEmpty(nextLevel.ScenePath))
            SceneManager.LoadScene(nextLevel);
        else
            Debug.Log("End of game!");
    }

    public void OnRestart()
    {
        playerManager.aliveManager.aliveController.ToggleActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}