using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource carSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Music")]
    public AudioClip backgroundMusic;
    public AudioClip car;

    [Header("SFX")]
    public AudioClip shoot;
    public AudioClip collectCoin;

    private void Start()
    {
        PlayMusic(backgroundMusic);
        PlayCarSound(car);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayCarSound(AudioClip clip)
    {
        carSource.clip = clip;
        carSource.loop = true;
        carSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
