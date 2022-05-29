using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndScreen : MonoBehaviour
{
    public SceneReference mainScreen;
    public GameObject exitButton;
    public Image blackScreen;
    public GameObject epilogueText;

    void Start()
    {
        AudioPlayerManager.instance.StopMusic();
    }

    public void Exit()
    {
        exitButton.SetActive(false);
        epilogueText.SetActive(true);
        Sequence endSequence = DOTween.Sequence();
        endSequence.Pause();
        endSequence.Append(blackScreen.DOFade(1f, 3f));
        endSequence.AppendInterval(1f);
        endSequence.OnComplete(() => {
            SceneManager.LoadScene(mainScreen);
        });
        endSequence.Play();
    }

}
