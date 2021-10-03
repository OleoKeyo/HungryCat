using DefaultNamespace;

namespace StaticData
{
  public class StaticDataService : IStaticDataService
  {
    public GameConfig LoadConfig()
    {
      return new GameConfig();
    }
  }
}