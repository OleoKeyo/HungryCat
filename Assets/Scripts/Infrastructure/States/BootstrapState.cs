using System;
using AlchemyCat.Infrastructure.AssetManagement;
using AlchemyCat.Infrastructure.Factory;
using AlchemyCat.Infrastructure.SceneManagement;
using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.Services.Input;
using Infrastructure.Services.AllServices;
using LevelGeneration;
using UnityEngine;

namespace AlchemyCat.Infrastructure.States
{
  public class BootstrapState : IPayloadedState<string>
  {
    private const string Initial = "Initial";
    
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly ServiceContainer _services;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceContainer services)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _services = services;

      RegisterServices();
    }

    private void RegisterServices()
    {
      RegisterStaticData();
      
      _services.RegisterSingle<IGameStateMachine>(_stateMachine);
      _services.RegisterSingle<IInputService>(RegisterInputService());
      _services.RegisterSingle<IAssetProvider>(new AssetProvider());
      _services.RegisterSingle<IGameFactory>(new GameFactory(
        _services.Resolve<IAssetProvider>(),
        _services.Resolve<IInputService>(),
        _services.Resolve<IGameStateMachine>(),
        _services.Resolve<IStaticDataService>()));
      _services.RegisterSingle<ILevelGenerationService>(new LevelGenerationService());
    }

    private void RegisterStaticData()
    {
      IStaticDataService staticDataService = new StaticDataService();
      staticDataService.Load();
      _services.RegisterSingle<IStaticDataService>(staticDataService);
    }

    private IInputService RegisterInputService()
    {
      if (Application.isEditor)
        return new StandaloneInputService();
      return new MobileInputService();
    }

    public void Enter(string sceneName)
    {
      if (sceneName == Initial)
        _sceneLoader.Load(sceneName, LoadStartMenu);
      else
        _sceneLoader.Load(sceneName, () => EnterLoadLevel(sceneName));
    }

    private void EnterLoadLevel(string sceneName) =>
      _stateMachine.Enter<LoadLevelState, string>(sceneName);

    private void LoadStartMenu() =>
      _stateMachine.Enter<StartMenuState>();


    public void Exit(){}
    
  }
}