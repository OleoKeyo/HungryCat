using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementInventory : MonoBehaviour
{
  public readonly List<Element> elements = new List<Element>();
  [SerializeField] private GameObject elementPrefab;

  public Transform rightHand;
  public Transform leftHand;

  public void AddElement(Element element)
  {
    if(elements.Contains(element))
      return;

    GameObject elementGo;
    if (elements.Count == 0)
      elementGo = Instantiate(elementPrefab, rightHand);
    else 
      elementGo = Instantiate(elementPrefab, leftHand);
    
    Element newElement = elementGo.GetComponent<Element>();
    newElement.SetElement(element.ElementType);
    
    elements.Add(newElement);
  }
}
