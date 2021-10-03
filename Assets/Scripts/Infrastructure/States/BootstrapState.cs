using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Input;
using Infrastructure.Services;
using StaticData;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
  public class BootstrapState : IState
  {
    private const string Initial = "Initial";
    private const string Main = "Main";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _services = services;
      
      RegisterServices();
    }

    public void Enter()
    {
      _sceneLoader.Load(Initial, onLoaded: () => EnterLoadLevel(Main));
    }

    public void Exit()
    {
    }

    private void EnterLoadLevel(string sceneName)
    {
      _stateMachine.Enter<LoadGameState, string>(sceneName);
    }
    
    private void RegisterServices()
    {
      _services.RegisterSingle<IStaticDataService>(RegisterStaticData());
      _services.RegisterSingle<IInputService>(RegisterInputService());
      _services.RegisterSingle<IAssetProvider>(new AssetProvider());
      
      _services.RegisterSingle<IGameFactory>(
        new GameFactory(
          _services.Resolve<IAssetProvider>(),
          _services.Resolve<IInputService>()));
    }

    private IStaticDataService RegisterStaticData()
    {
      IStaticDataService staticData = new StaticDataService();
      staticData.LoadConfig();
      return staticData;
    }

    private IInputService RegisterInputService()
    {
      return new StandaloneInputService();
    }
  }
}