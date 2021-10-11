using System;
using System.Collections;
using System.Collections.Generic;
using AlchemyCat.Player;
using DefaultNamespace.Player;
using UnityEngine;
[RequireComponent(typeof(PlayerAudio))]
public class PlayerInventory : MonoBehaviour
{
  [SerializeField] private GameObject elementPrefab;
  public readonly List<Element> elements = new List<Element>();

  public Transform rightHand;
  public Transform leftHand;
  
  private PlayerAudio _audio;

  private void Awake()
  {
    _audio = GetComponent<PlayerAudio>();
  }

  public void AddElement(Element element)
  {
    GameObject elementGo;
    if (elements.Count == 0)
      elementGo = Instantiate(elementPrefab, rightHand);
    else 
      elementGo = Instantiate(elementPrefab, leftHand);
    
    Element newElement = elementGo.GetComponent<Element>();
    newElement.SetElement(element.ElementType);
    
    elements.Add(newElement);
  }
  
  public void TakeElement(Element element)
  {
    if (elements.Count < 2 && !elements.Contains(element))
    {
      _audio.PlayGetFlask();
      AddElement(element);
    }
  }

  public void ClearInventory()
  {
    foreach (Element element in elements)
    {
      Destroy(element.gameObject);
    }
    elements.Clear();
  }
}
