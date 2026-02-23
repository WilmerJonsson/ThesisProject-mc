using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Text masterTxt;
    [SerializeField] TMP_Text sfxTxt;
    [SerializeField] TMP_Text ambienceTxt;

    [SerializeField] bool isMuted;

    public void SetMasterVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        masterTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", MathF.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        sfxTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", MathF.Log10(volume) * 20);

    }
    public void SetAmbienceVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        ambienceTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbienceVolume", MathF.Log10(volume) * 20);
    }

    public void MuteAllAudio()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
}
