using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;
    [SerializeField] private UISoundSlider slider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
/*            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }*/
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
    }

    private void Update()
    {
        slider.ChangeVolume();
        if (UIManager.isPauseGame||End.isWin)
            sounds[0].source.pitch = 0;
        else
            sounds[0].source.pitch = 1;
    }
    private void Start()
    {
        VolumeController(slider.musicSlider.value);
        PlaySounds("Theme");
    }

    public void PlaySounds(string _name)
    {
        sounds[0] = Array.Find(sounds, sound => sound.name == _name);
        if (sounds[0] == null)
            return;
        sounds[0].source.Play();
    }

    public void VolumeController(float _volume)
    {
        sounds[0].source.volume = _volume;
    }
}
