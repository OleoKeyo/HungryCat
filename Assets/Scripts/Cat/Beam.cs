using System;
using System.Collections;
using AlchemyCat.Cat;
using AlchemyCat.Player;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Beam : MonoBehaviour, IAttack
{
    private static readonly int ScrollSpeedId = Shader.PropertyToID("_ScrollSpeed");
    
    private AudioSource _audio;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public ElementType type;
    public Vector2 scrollSpeed;

    private bool _triggered;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        IsEnable(false);
        spriteRenderer.material.SetVector(ScrollSpeedId, scrollSpeed);
    }
    
    public void IsEnable(bool isEnable)
    {
        spriteRenderer.enabled = isEnable;
        boxCollider.enabled = isEnable;
        if (isEnable)
        {
            _audio.Play();
        }
        else
        {
            _audio.Stop();
        }
    }
    
    public ElementType GetElementType() => 
        type;
}
