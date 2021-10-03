using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure
{
  public class Game
  {
    public readonly GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner)
    {
      AllServices services = new AllServices();
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), services);
    }
  }
}