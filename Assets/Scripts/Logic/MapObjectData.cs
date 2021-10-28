using System;
using UnityEngine;

namespace Logic
{
  [Serializable]
  public class MapObjectData
  {
    public Vector2Int size;
    public Vector3 position;
    public Vector3 minBounds;

    public MapObjectData(Vector3 position, Vector2Int size, Vector3 minBounds)
    {
      this.size = size;
      this.position = position;
      this.minBounds = minBounds;
    }
  }
}