using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        if (instance == null)
            instance = this;
    }
    
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
