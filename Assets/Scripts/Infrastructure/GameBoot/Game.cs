using AlchemyCat.Infrastructure.SceneManagement;
using AlchemyCat.Infrastructure.States;
using Infrastructure.Services.AllServices;

namespace AlchemyCat.Infrastructure.GameBoot
{
  public class Game
  {
    public readonly GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, new ServiceContainer());
    }
  }
}