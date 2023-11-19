using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSystem : Singleton<AudioSystem>
{
    // [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _SFXSource;

    private void Start()
    {
        // audioMixer.SetFloat("SFX", -15f);
        // audioMixer.SetFloat("Music", -20f);
    }

    public void PlayMusic (AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlaySound()
    {
        _SFXSource.Play();
    }
}