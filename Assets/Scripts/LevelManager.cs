using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // public string nextLevel;
    public SceneReference nextLevel;
    public AliveController alivePlayer;
    public Goal goal;

    void Start()
    {
        goal.ClearEventHandlers();
        goal.goalCompleteEvent += GoToNextLevel;

        alivePlayer.ClearEventHandlers();
        alivePlayer.restartLevelEvent += ReloadLevel;
    }

    public void GoToNextLevel()
    {
        if(!string.IsNullOrEmpty(nextLevel.ScenePath))
            SceneManager.LoadScene(nextLevel);
        else
            Debug.Log("End of game!");
    }

    public void ReloadLevel()
    {
        alivePlayer.isActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


// public class LevelManager : MonoBehaviour
// {
//     #region Singleton Stuff
//     static LevelManager instance;
//     public static LevelManager Instance { get { return instance; } }

//     protected virtual void Awake()
//     {
//         if (instance != null)
//         {
//             Debug.LogErrorFormat("[Singleton] Trying to instantiate a second instance of singleton class {0} from {1}", GetType().Name, this.gameObject.name);
//             Destroy(this.gameObject);
//         }
//         else
//         {
//             instance = this;
//         }
//     }

//     protected virtual void OnDestroy()
//     {
//         if (instance == this)
//         {
//             instance = null;
//         }
//     }
//     #endregion

//     PlayerController player;

//     void Start()
//     {
//         player = FindObjectOfType<PlayerController>();
//     }

//     public void ReloadLevel()
//     {
//         player.isActive = false;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }
// }
