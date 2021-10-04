using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace LevelGeneration
{
  public class LevelGeneration : MonoBehaviour
  {
    public CratesContainer container;
    public Door door;

    private Random _random;
    private int _elementsCount;
    private List<ElementType> _generatedElements = new List<ElementType>();
    
    public void Awake()
    {
      int seed = (int)DateTime.Now.Ticks;
      _random = new Random(seed);
      _elementsCount = Enum.GetValues(typeof(ElementType)).Length;
      
      int neededElementsCount = container.Crates.Count;
      while (_generatedElements.Count != neededElementsCount)
      {
        _generatedElements.Add(GetRandomElement());
      }
      
      ElementType winnerType = GetWinnerElement();
      door.SetRightDoorElement(winnerType);
    }

    private ElementType GetWinnerElement()
    {
      int randomNumber = _random.Next(_generatedElements.Count + 1);
      return _generatedElements[randomNumber];
    }

    private ElementType GetRandomElement()
    {
      int randomNumber = _random.Next(_elementsCount + 1);
      ElementType randomType = (ElementType)randomNumber;
      return _generatedElements.Contains(randomType) ? GetRandomElement() : randomType;
    }
  }
}