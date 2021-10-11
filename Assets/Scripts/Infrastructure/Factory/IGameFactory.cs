using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.UI;
using ElementCrate;
using Infrastructure.Services.AllServices;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    GameObject CreatePlayer(Vector2 at);
    GameObject CreateCat(Vector2 at);
    void CreateCrate(Vector2 at, ElementType elementType);
    void CreateStartMenu();
    GameObject CreateDoor(Vector2 at, LevelTransferData levelDataLevelTransferData,
      ElementType doorType);
    GameObject CreateLevelTransformTrigger(LevelTransferData transferData);
  }
}