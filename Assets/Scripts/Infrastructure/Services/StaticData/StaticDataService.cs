using System.Collections.Generic;
using System.Linq;
using AlchemyCat.StaticData;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private const string StaticDataLevelsPath = "StaticData/Levels";

    private Dictionary<string, LevelStaticData> _levels;

    public void Load() =>
      _levels = Resources.LoadAll<LevelStaticData>(StaticDataLevelsPath).ToDictionary(x => x.levelKey, x => x);
    
    public LevelStaticData ForLevel(string sceneName) =>
      _levels.TryGetValue(sceneName, out LevelStaticData staticData) ? staticData : null;

  }
}