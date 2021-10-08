using System;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Services.StaticData
{
  [Serializable]
  public class DoorStaticData
  {
    public ElementType rightElementForOpen;
    public Vector2 position;

    public DoorStaticData(ElementType elementType, Vector2 pos)
    {
      rightElementForOpen = elementType;
      position = pos;
    }
  }
}