using System.Collections.Generic;
using System.Linq.Expressions;
using AlchemyCat.Infrastructure.Factory;
using AlchemyCat.Infrastructure.SceneManagement;
using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.StaticData;
using LevelGeneration;
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
    private readonly ILevelGenerationService _levelGenerationService;
    
    public LoadLevelState(
      GameStateMachine gameStateMachine, 
      SceneLoader sceneLoader, 
      LoadingCurtain curtain, 
      IGameFactory gameFactory, 
      IStaticDataService staticDataService,
      ILevelGenerationService levelGenerationService)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      _gameFactory = gameFactory;
      _staticDataService = staticDataService;
      _levelGenerationService = levelGenerationService;
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
      GameObject cat = _gameFactory.CreateCat(levelData.catPosition);
      List<ElementType> generatedElements = _levelGenerationService.Generate(levelData.doorData.rightElementForOpen);

      for (int i = 0; i < levelData.crateSpawnerPositions.Count; i++)
      {
        Vector2 cratePosition = levelData.crateSpawnerPositions[i];
        ElementType crateElement = generatedElements[i];
        _gameFactory.CreateCrate(cratePosition, crateElement);
      }
      GameObject door = _gameFactory.CreateDoor(levelData.doorData.position, levelData.levelTransferData, levelData.doorData.rightElementForOpen);
      
    }
  }
}