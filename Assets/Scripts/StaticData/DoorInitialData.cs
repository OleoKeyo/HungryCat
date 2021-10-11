using System;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Services.StaticData
{
  [Serializable]
  public class DoorInitialData
  {
    public ElementType rightElementForOpen;
    public Vector2 position;

    public DoorInitialData(ElementType elementType, Vector2 pos)
    {
      rightElementForOpen = elementType;
      position = pos;
    }
  }
}