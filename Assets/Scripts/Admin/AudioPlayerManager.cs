using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    public static AudioPlayerManager instance = null;
    public AudioSource bgMusic;
    public AudioSource successSound;

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

    public void StartMusic()
    {
        bgMusic.Play();
    }

    public void StopMusic()
    {
        bgMusic.Stop();
    }
}