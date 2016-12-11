using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public static MusicManager SharedInstance;

    //First element in list will be default song on load
    public List<AudioClip> musicList;
    private AudioSource thisAudio;
    private bool isPaused = false;

    void Awake()
    {
        SharedInstance = this;
        thisAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        thisAudio.clip = musicList[0];
        thisAudio.volume = 0.20f;
    }

    void Update()
    {
        if (!isPaused && !thisAudio.isPlaying)
            thisAudio.Play();
    }

    public void ChangeSong(string songTitle)
    {
        for (int i = 0; i < musicList.Count; i++)
        {
            if (musicList[i].name == songTitle)
            {
                thisAudio.clip = musicList[i];
                break;
            }
        }
    }

    public void ChangeSong(string songTitle, float delay)
    {
        for (int i = 0; i < musicList.Count; i++)
        {
            if (musicList[i].name == songTitle)
            {
                if (thisAudio.isPlaying)
                {
                    thisAudio.Stop();
                }
                thisAudio.clip = musicList[i];
                thisAudio.PlayDelayed(delay);
            }
        }
    }

    public void ChangeSong(string songTitle, float delay, float volume)
    {
        for (int i = 0; i < musicList.Count; i++)
        {
            if (musicList[i].name == songTitle)
            {
                if (thisAudio.isPlaying)
                {
                    thisAudio.Stop();
                }
                thisAudio.clip = musicList[i];
                thisAudio.volume = volume;
                thisAudio.PlayDelayed(delay);
            }
        }
    }
}
