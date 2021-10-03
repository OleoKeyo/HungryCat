using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    Player CreatePlayer(Vector3 position);
    void CreateCat(Vector3 position);
  }
}