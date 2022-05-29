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
        if(goal)
        {
            goal.ClearEventHandlers();
            goal.goalCompleteEvent += GoToNextLevel;
        }
    }

    public void GoToNextLevel()
    {
        AudioPlayerManager.instance.successSound.Play();
        LoadLevel(nextLevel);
    }

    public void OnRestart()
    {
        playerManager.aliveManager.aliveController.ToggleActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(SceneReference level)
    {
        if(!string.IsNullOrEmpty(level.ScenePath))
            SceneManager.LoadScene(level);
        else
            Debug.Log("End of game!");
    }
}