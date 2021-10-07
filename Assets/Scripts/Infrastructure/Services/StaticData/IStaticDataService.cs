using AlchemyCat.StaticData;
using Infrastructure.Services.AllServices;

namespace AlchemyCat.Infrastructure.Services.StaticData
{
  public interface IStaticDataService : IService
  {
    void Load();
    LevelStaticData ForLevel(string sceneName);
  }
}