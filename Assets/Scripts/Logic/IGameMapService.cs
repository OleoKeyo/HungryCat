using Infrastructure.Services.AllServices;

namespace Logic
{
  public interface IGameMapService : IService
  {
    void Init(GameTilemap gameTilemap);
    GameTilemap GetGameMap();
  }
}