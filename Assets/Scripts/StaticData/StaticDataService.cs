using System.Collections.Generic;
using System.Linq;
using AlchemyCat.StaticData;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private const string StaticDataLevelsPath = "StaticData/Levels";
    private const string StaticDataDoorsPath = "StaticData/Doors";

    private Dictionary<string, LevelStaticData> _levels;
    private Dictionary<ElementType, DoorData> _doors;

    public void Load()
    {
      _levels = Resources.LoadAll<LevelStaticData>(StaticDataLevelsPath).ToDictionary(x => x.levelKey, x => x);
      LoadDoorConfig();
    }

    private void LoadDoorConfig()
    {
      _doors = Resources.LoadAll<DoorStaticData>(StaticDataDoorsPath)
        .ToDictionary(x => x.doorData.rightElementForOpen, x => x.doorData);
    }

    public LevelStaticData ForLevel(string sceneName) =>
      _levels.TryGetValue(sceneName, out LevelStaticData staticData) ? staticData : null;

    public DoorData ForDoor(ElementType type) =>
      _doors.TryGetValue(type, out DoorData staticData) ? staticData : null;
  }
}