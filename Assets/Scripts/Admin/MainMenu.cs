using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject levelSelect;
    public LevelManager levelManager;
    public List<LevelButton> levelButtons;

    void Start()
    {
        ShowMenu();
        AudioPlayerManager.instance.StartMusic();
        levelButtons.ForEach(levelButton => {
            levelButton.ClearEventHandlers();
            levelButton.loadLevel += LoadLevel;
        });
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void ShowLevels()
    {
        menu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void LoadLevel(SceneReference level)
    {
        levelManager.LoadLevel(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
