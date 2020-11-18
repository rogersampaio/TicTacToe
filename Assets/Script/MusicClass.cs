using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicClass : MonoBehaviour
{
    private static MusicClass instance = null;
    public static MusicClass Instance { get { return instance; } }

    private float musicVolume = 1f;

    public AudioSource _audioSource;

    public Slider sliderVolume;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Play();
        }
    }

    private void Start(){
        if (instance != null)
        {
            sliderVolume.value = instance.musicVolume;
        }
    }

    public void Play()
    {
        _audioSource.Play();
    }
    void Update()
    {
        _audioSource.volume = musicVolume;
    }

    public static void SetVolume(float vol)
    {
        if (instance != null)
        {
            instance.musicVolume = vol;
            return;
        }
    }
}
