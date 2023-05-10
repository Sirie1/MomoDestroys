using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource, effectsSource;
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SoundManager was NULL, creating game manager");
                GameObject go = new GameObject("SoundManager");
                go.AddComponent<SoundManager>();
            }
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this; //Initialization of the private instance
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume (float value)
    {
        AudioListener.volume = value;
    }
    public void ToggleFX()
    {
        effectsSource.mute = !effectsSource.mute;
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
}
