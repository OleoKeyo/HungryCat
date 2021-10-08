using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace LevelGeneration
{
  public class LevelGenerationService : ILevelGenerationService
  {
    private readonly Random _random;
    private readonly Array _elementTypes;
    private readonly List<ElementType> _generatedElements = new List<ElementType>();
    
    public LevelGenerationService()
    {
      int seed = (int)DateTime.Now.Ticks;
      _random = new Random(seed);
      _elementTypes = Enum.GetValues(typeof(ElementType));
    }

    public List<ElementType> Generate(ElementType doorElement)
    {
      foreach (ElementType elementType in _elementTypes)
      {
        if (doorElement.HasFlag(elementType) && elementType != ElementType.Unknown)
        {
          _generatedElements.Add(elementType);
          Debug.Log(elementType);
        }
      }
      return _generatedElements;
    }
    
  }
}