using AlchemyCat.StaticData;
using Infrastructure.Services.AllServices;

namespace LevelGeneration
{
  public interface ILevelGenerationService : IService
  {
    GeneratedElements Generate(LevelStaticData levelStaticData);
  }
}