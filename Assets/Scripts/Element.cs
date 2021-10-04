using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public ElementsConfig elementsConfig;

  public ElementType ElementType;

  public void SetElement(ElementType elementType)
  {
    ElementType = elementType;
    spriteRenderer.sprite = elementsConfig.GetElementSprite(ElementType);
  }
}
