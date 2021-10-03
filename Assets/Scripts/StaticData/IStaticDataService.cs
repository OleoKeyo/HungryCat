using DefaultNamespace;
using Infrastructure.Services;

namespace StaticData
{
  public interface IStaticDataService : IService
  {
    GameConfig LoadConfig();
  }
}