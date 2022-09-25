using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundSlider : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;
    [SerializeField] private GameObject[] soundManager;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            LoadMusic();
        }
        else
        {
            LoadMusic();
        }
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadSound();
        }
        else
        {
            LoadSound();
        }

    }

    public void ChangeVolume()
    {
        AudioManager.instance.VolumeController(musicSlider.value);
        foreach(GameObject child in soundManager)
        {
            child.gameObject.GetComponent<AudioSource>().volume = soundSlider.value;
        }
        Save();
    }
    private void LoadMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void LoadSound()
    {
        musicSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("soundVolume", soundSlider.value);
    }
}
