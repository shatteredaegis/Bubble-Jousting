using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip popSFX;
    [SerializeField] private AudioClip countdownSFX;
    [SerializeField] private AudioSource combatMusic;
    [SerializeField] private AudioClip shieldClashSFX;
    [SerializeField] private AudioClip swordClashSFX;

    public bool fadingMusic;


    private void Update()
    {
        FadeMusicOut();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void playPopSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(popSFX);
    }

    public void PlaySwordHitSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(swordClashSFX);
    }

    public void PlayShieldHitSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(shieldClashSFX);
    }
    public void playCDSFX()
    {
        audioSource.PlayOneShot(countdownSFX);
    }

    public void PlayMusic()
    {
        combatMusic.Play();
    }

    private void FadeMusicOut()
    {
        if (!fadingMusic)
            return;
        
        combatMusic.volume -= (Time.unscaledDeltaTime * 0.5f);
    }
}