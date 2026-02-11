using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMovement(InputValue input)
    {
        if (audioSource.clip != SoundBank.Instance.stepAudio)
        {
            audioSource.clip = SoundBank.Instance.stepAudio;
            audioSource.loop = true;
        }

        if (!audioSource.isPlaying) audioSource.Play();
    }
    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
    }
}
