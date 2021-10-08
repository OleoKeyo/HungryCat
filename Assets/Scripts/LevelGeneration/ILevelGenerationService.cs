using System.Collections.Generic;
using AlchemyCat.StaticData;
using Infrastructure.Services.AllServices;

namespace LevelGeneration
{
  public interface ILevelGenerationService : IService
  {
    List<ElementType> Generate(ElementType rightDoorElement);
  }
}