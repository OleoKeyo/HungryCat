using AlchemyCat.Infrastructure.Factory;
using AlchemyCat.Infrastructure.SceneManagement;
using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.StaticData;
using UnityEngine;

namespace AlchemyCat.Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticDataService;
    
    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory, IStaticDataService staticDataService)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      _gameFactory = gameFactory;
      _staticDataService = staticDataService;
    }

    public void Enter(string sceneName)
    {
      _curtain.Show();
      _sceneLoader.Load(sceneName, () => OnLoaded(sceneName));
    }
    
    public void Exit() =>
      _curtain.Hide();

    private void OnLoaded(string sceneName)
    {
      InitLevel(sceneName);
      _gameStateMachine.Enter<GameLoopState>();
    }

    private void InitLevel(string sceneName)
    {
      LevelStaticData levelData = _staticDataService.ForLevel(sceneName);
      GameObject player = _gameFactory.CreatePlayer(levelData.initialPlayerPosition);
      GameObject cat = _gameFactory.CreateCat(levelData.initialCatPosition);
      GameObject door = _gameFactory.CreateDoor(levelData.initialDoorPosition);
    }
  }
}