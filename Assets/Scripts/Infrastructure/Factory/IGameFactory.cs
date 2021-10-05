using Infrastructure.Services.AllServices;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    GameObject CreatePlayer(Vector2 at);
    GameObject CreateCat(Vector2 at);
    GameObject CreateCrate(Vector2 at);
  }
}