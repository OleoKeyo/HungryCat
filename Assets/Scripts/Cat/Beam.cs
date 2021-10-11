using System;
using System.Collections;
using AlchemyCat.Cat;
using AlchemyCat.Player;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Beam : MonoBehaviour, IAttack
{
    private AudioSource _audio;
    
    public float rotationSpeed = 30;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public ElementType type;
    
    private bool _triggered;
    
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        IsEnable(false);
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
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
