using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("IDLE SOUNDS")]
    [SerializeField] private float idleTimer = 0f;
    [SerializeField] private bool isMoving = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= 5f)
            {
                IdleSounds();
            }
        }
        else
        {
            idleTimer = 0f;
        }
    }
    private void OnMovement(InputValue input)
    {
        if (audioSource.clip != SoundBank.Instance.stepAudio)
        {
            audioSource.clip = SoundBank.Instance.stepAudio;
            audioSource.loop = true;
        }

        if (!audioSource.isPlaying) audioSource.Play();
        isMoving = true;
    }
    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
        isMoving = false;
    }

    void IdleSounds()
    {
        if (audioSource.clip != SoundBank.Instance.idleAudio)
        {
            audioSource.clip = SoundBank.Instance.idleAudio;
            audioSource.loop = true;
        }

        if (!audioSource.isPlaying) audioSource.Play();
    }
}
