using System.Collections;
using UnityEngine;

namespace Config
{
  [RequireComponent(typeof(AudioSource))]
  public class DoorAudio : MonoBehaviour
  {
    private AudioClip _successSound;
    private AudioClip _failSound;
    private AudioSource _audioSource;

    public void Construct(AudioClip successSound, AudioClip failSound)
    {
      _successSound = successSound;
      _failSound = failSound;
    }

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySuccess()
    {
      PlaySound(_successSound);
    }

    public void PlayFail()
    {
      PlaySound(_failSound);
    }

    private void PlaySound(AudioClip audioClip)
    {
      _audioSource.clip = audioClip;
      _audioSource.Play();
    }
  }
}