﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Instance
    public static SoundManager instance;

    //Audiosource
    AudioSource source;

    //Audio Clips
    public AudioClip
        jump,
        impact,
        eat,
        happy,
        whimper,
        explosion,
        health;


    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        instance = this;
    }

    public void PlayEat()
    {
        StartCoroutine(Eat());
    }

    IEnumerator Eat() //En jaksanu muokata audacitylla xD
    {
        source.PlayOneShot(health);
        source.PlayOneShot(eat);
        yield return new WaitForSeconds(0.5f);
        source.PlayOneShot(happy);
        yield return null;
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void PlaySound(AudioClip clip, float volume)
    {
        source.PlayOneShot(clip, volume);
    }
}
