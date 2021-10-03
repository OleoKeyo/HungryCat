using Infrastructure.Factory;

namespace DefaultNamespace.GameService
{
  public class GameService : IGameService
  {
    public int DifficultLevel { get; set; }

    private readonly IGameFactory _gameFactory;

    public GameService(IGameFactory gameFactory)
    {
      _gameFactory = gameFactory;
    }

  }
}