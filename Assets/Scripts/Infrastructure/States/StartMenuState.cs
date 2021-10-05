using AlchemyCat.Infrastructure.Factory;
using AlchemyCat.Infrastructure.SceneManagement;

namespace AlchemyCat.Infrastructure.States
{
  public class StartMenuState : IState
  {
    private const string StartMenuScene = "StartMenu";
    
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    
    public StartMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
      InitMenu();
      _curtain.Hide();
    }
    
    private void InitMenu()
    {
      _gameFactory.CreateStartMenu();
    }

    public void Exit()
    {
    }
  }
}