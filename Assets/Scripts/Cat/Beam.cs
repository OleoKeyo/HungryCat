using AlchemyCat.Cat;
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
        spriteRenderer.material.SetVector(ScrollSpeedId, scrollSpeed);
    }
    
    public ElementType GetElementType() => 
        type;
}
