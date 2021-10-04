using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public ElementsConfig elementsConfig;
  
  private ElementType _elementType;

  public void SetElement(ElementType elementType)
  {
    _elementType = elementType;
    spriteRenderer.sprite = elementsConfig.GetElementSprite(_elementType);
  }
}
