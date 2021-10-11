using System;
using UnityEngine;

public class Element : MonoBehaviour, IEquatable<Element>
{
  public SpriteRenderer spriteRenderer;
  public ElementsConfig elementsConfig;
  
  public ElementType ElementType;

  public void SetElement(ElementType elementType)
  {
    ElementType = elementType;
    spriteRenderer.sprite = elementsConfig.GetElementSprite(ElementType);
  }

  public bool Equals(Element other) =>
    ElementType == other.ElementType;
  
  public override bool Equals(object obj) => 
    Equals((Element)obj);
  
  public override int GetHashCode()
  {
    unchecked
    {
      int hashCode = base.GetHashCode();
      hashCode = (hashCode * 397) ^ (int)ElementType;
      return hashCode;
    }
  }
}
