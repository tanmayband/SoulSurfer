using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance = null;
    public SceneReference mainScreen;
    private bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    void Start()
    {
        SetPauseMenu(false);
    }

    public void SetPauseMenu(bool show)
    {
        isPaused = show;
        gameObject.SetActive(show);
        Time.timeScale = show ? 0f : 1f;
    }

    public void TogglePauseMenu()
    {
        SetPauseMenu(!isPaused);
    }

    public void Exit()
    {
        SetPauseMenu(false);
        SceneManager.LoadScene(mainScreen);
    }
}
