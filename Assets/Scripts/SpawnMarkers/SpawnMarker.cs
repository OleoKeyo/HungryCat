using System;
using UnityEngine;

namespace AlchemyCat.SpawnMarkers
{
  [RequireComponent(typeof(SpriteRenderer))]
  public class SpawnMarker : MonoBehaviour
  {
    public SpriteRenderer SpriteRenderer;

    public void Awake()
    {
      if (Application.isPlaying)
      {
        gameObject.SetActive(false);
      }
    }
  }
}