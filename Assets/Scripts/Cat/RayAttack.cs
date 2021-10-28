using System;
using System.Collections;
using UnityEngine;

namespace AlchemyCat.Cat
{
  public class RayAttack : MonoBehaviour, IAttack
  {
    private static readonly int ScrollSpeedId = Shader.PropertyToID("_ScrollSpeed");
    
    private ElementType _elementType = ElementType.Fire;
    public Vector2 scrollSpeed;
    public SpriteRenderer rayRenderer;

    public ElementType GetElementType() => 
      _elementType;

    private void Awake()
    {
      rayRenderer.material.SetVector(ScrollSpeedId, scrollSpeed);
    }

    private void OnEnable() =>
      StartCoroutine(DestroyTimer(0.5f));

    private IEnumerator DestroyTimer(float timer)
    {
      yield return new WaitForSeconds(timer);
      Destroy(gameObject);
    }
  }
}