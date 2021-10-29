namespace Logic
{
  public class GameMapService : IGameMapService
  {
    private GameTilemap _gameTilemap;

    public void Init(GameTilemap gameTilemap) =>
      _gameTilemap = gameTilemap;

    public GameTilemap GetGameMap() => 
      _gameTilemap;
  }
}