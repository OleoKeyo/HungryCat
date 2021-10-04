using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementsConfig", menuName = "Elements")]
public class ElementsConfig : ScriptableObject
{
  public List<ElementData> elements;

  private Dictionary<ElementType, ElementData> dataByType;
  
  public Sprite GetElementSprite(ElementType elementType)
  {
    if (dataByType == null)
    {
      CollectData();
    }
    return dataByType[elementType].sprite;
  }

  private void CollectData()
  {
    dataByType = new Dictionary<ElementType, ElementData>();
    foreach (ElementData element in elements)
    {
      dataByType[element.type] = element;
    }
  }
}
