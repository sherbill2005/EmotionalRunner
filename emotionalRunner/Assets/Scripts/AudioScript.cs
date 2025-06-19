using System;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static AudioScript instance;
    public AudioSource bgMusicSource;
    public AudioClip HappyClip, SadClip, AngryClip, ScaredClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void Music(String mood)
    {
        switch (mood)
        {
            case "Happy":
                bgMusicSource.clip = HappyClip;
                break;
            case "Angry":
                bgMusicSource.clip = AngryClip;
                break;
            case "Sad":
                bgMusicSource.clip = SadClip;
                break;
            case "Scared":
                bgMusicSource.clip = ScaredClip;
                break;
            default:
                return;
        }
        bgMusicSource.Play();
    }
    public void StopMusic()
    {
        bgMusicSource.Stop();
    }
}
