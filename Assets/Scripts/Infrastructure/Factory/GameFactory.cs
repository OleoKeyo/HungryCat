using AlchemyCat.Infrastructure.AssetManagement;
using AlchemyCat.Infrastructure.States;
using AlchemyCat.Services.Input;
using AlchemyCat.UI;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssetProvider _assets;
    private readonly IInputService _inputService;
    private readonly IGameStateMachine _gameStateMachine;
    
    public GameFactory(IAssetProvider assets, IInputService inputService, IGameStateMachine gameStateMachine)
    {
      _assets = assets;
      _inputService = inputService;
      _gameStateMachine = gameStateMachine;
    }

    public GameObject CreatePlayer(Vector2 at)
    {
      return Instantiate(AssetPath.PlayerPath, at);
    }

    public GameObject CreateCat(Vector2 at)
    {
      return Instantiate(AssetPath.CatPath, at);
    }

    public GameObject CreateDoor(Vector2 at)
    {
      return Instantiate(AssetPath.DoorPath, at);
    }

    public GameObject CreateCrate(Vector2 at)
    {
      return Instantiate(AssetPath.CatPath, at);
    }

    public void CreateStartMenu()
    {
      GameObject startMenuGo = Instantiate(AssetPath.StartMenuPath);
      var startMenu = startMenuGo.GetComponent<StartMenu>();
      startMenu.Construct(_gameStateMachine);
    }

    private GameObject Instantiate(string prefabPath, Vector2 position)
    {
      GameObject heroGameObject = _assets.Instantiate(prefabPath, position);
      return heroGameObject;
    }

    private GameObject Instantiate(string prefabPath)
    {
      GameObject heroGameObject = _assets.Instantiate(prefabPath);
      return heroGameObject;
    }
  }
}