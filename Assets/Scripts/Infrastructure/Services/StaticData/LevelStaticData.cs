using System.Collections.Generic;
using UnityEngine;

namespace AlchemyCat.StaticData
{
  [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
  public class LevelStaticData : ScriptableObject
  {
    public string levelKey;
    public List<Vector2> crateSpawnerPositions;
    public Vector2 initialPlayerPosition;
    public Vector2 initialCatPosition;
    public Vector2 initialDoorPosition;
  }
}