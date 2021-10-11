using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlchemyCat.Player
{
  [RequireComponent(typeof(AudioSource))]
  public class PlayerAudio : MonoBehaviour
  {
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip getFlask;
    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeath()
    {
      PlaySound(deathSound);
    }
    
    public void PlayGetFlask()
    {
      PlaySound(getFlask);
    }

    private void PlaySound(AudioClip audioClip)
    {
      _audioSource.clip = audioClip;
      _audioSource.Play();
    }
  }
}