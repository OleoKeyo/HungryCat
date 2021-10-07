using System;
using System.Collections.Generic;
using AlchemyCat.StaticData;
using UnityEngine;
using Random = System.Random;

namespace LevelGeneration
{
  public class LevelGenerationService : ILevelGenerationService
  {
    private const int SimpleElementsCount = 3;
    
    private Random _random;
    private Array _elementsValues;
    private List<ElementType> _generatedElements = new List<ElementType>();
    
    public LevelGenerationService()
    {
      int seed = (int)DateTime.Now.Ticks;
      _random = new Random(seed);
      _elementsValues = Enum.GetValues(typeof(ElementType));
    }

    public GeneratedElements Generate(LevelStaticData levelStaticData)
    {
      int neededElementsCount = levelStaticData.crateSpawnerPositions.Count;
      while (_generatedElements.Count != neededElementsCount)
      {
        _generatedElements.Add(GetRandomElement());
      }
      ElementType winnerType = GetWinnerElement();

      return new GeneratedElements(_generatedElements, winnerType);
    }

    private ElementType GetWinnerElement()
    {
      ElementType winnerType = ElementType.Fire;
      List<ElementType> winnerCandidates = new List<ElementType>();
      int randomNumber = 0;
      switch (_generatedElements.Count)
      {
        case 1 :
          winnerType = _generatedElements[randomNumber];
          break;
        case 2 :
          winnerCandidates.AddRange(_generatedElements);
          winnerCandidates.Add((ElementType)((int)winnerCandidates[0] + (int)winnerCandidates[1]));
          randomNumber = _random.Next(winnerCandidates.Count);
          winnerType = winnerCandidates[randomNumber];
          break;
        case 3 :
          _elementsValues = Enum.GetValues(typeof(ElementType));
          randomNumber = _random.Next(_elementsValues.Length);
          winnerType = (ElementType) _elementsValues.GetValue(randomNumber);
          break;
      }
      return winnerType;
    }

    private ElementType GetRandomElement()
    {
      int randomNumber = _random.Next(SimpleElementsCount);
      Debug.Log(randomNumber);
      ElementType randomType = (ElementType)_elementsValues.GetValue(randomNumber);
      return _generatedElements.Contains(randomType) ? GetRandomElement() : randomType;
    }
  }
}