using System.Collections.Generic;
using AlchemyCat.Infrastructure.Services.StaticData;
using UnityEngine;

namespace AlchemyCat.StaticData
{
  [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
  public class LevelStaticData : ScriptableObject
  {
    public string levelKey;
    public List<Vector2> crateSpawnerPositions;
    public Vector2 initialPlayerPosition;
    public Vector2 catPosition;
    public DoorInitialData doorData;
    public LevelTransferData levelTransferData;
  }
}