using DefaultNamespace;
using Infrastructure.Factory;
using StaticData;
using UnityEngine;

namespace Infrastructure.States
{
  public class LoadGameState : IPayloadedState<string>
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticData;
    
    public LoadGameState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, 
      IStaticDataService staticData)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _gameFactory = gameFactory;
      _staticData = staticData;
    }

    public void Enter(string sceneName)
    {
      _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit()
    {
    }

    
    private void OnLoaded()
    {
      // InitUIRoot();
      InitGame();
      _gameStateMachine.Enter<GameLoopState>();
    }
    
    private void InitGame()
    {
      GameConfig gameConfig = _staticData.LoadConfig();
      Vector3 playerPosition = gameConfig.StartPlayerPosition;
      Player player = _gameFactory.CreatePlayer(playerPosition);
    }
  }
}