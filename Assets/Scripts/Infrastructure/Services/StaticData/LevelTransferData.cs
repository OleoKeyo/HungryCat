using System;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Services.StaticData
{
  [Serializable]
  public class LevelTransferData
  {
    public Vector2 position;
    public Quaternion rotation;
    public string transferTo;

    public LevelTransferData(Vector2 at, Quaternion rot, string to)
    {
      position = at;
      rotation = rot;
      transferTo = to;
    }
  }
}