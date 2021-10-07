using System.Linq.Expressions;
using AlchemyCat.Infrastructure.AssetManagement;
using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.Infrastructure.States;
using AlchemyCat.Services.Input;
using AlchemyCat.UI;
using Config;
using ElementCrate;
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

    public GameObject CreateDoor(
      Vector2 at, 
      LevelTransferData levelTransferData,
      ElementType winnerType)
    {
      GameObject doorGo = Instantiate(AssetPath.DoorPath, at);
      Door door = doorGo.GetComponent<Door>();
      door.Construct(levelTransferData, this, winnerType);
      return doorGo;
    }

    public GameObject CreateLevelTransformTrigger(LevelTransferData transferData)
    {
      GameObject levelTransferGo = Instantiate(AssetPath.LevelTransformTrigger, transferData.position, transferData.rotation);
      LevelTransferTrigger transferTrigger = levelTransferGo.GetComponent<LevelTransferTrigger>();
      transferTrigger.TransferTo = transferData.transferTo;
      return levelTransferGo;
    }

    public void CreateCrate(Vector2 at, ElementType element)
    {
      GameObject crateGo = Instantiate(AssetPath.CratePath, at);
      Crate crate = crateGo.GetComponent<Crate>();
      crate.SetElement(element);
    }

    public void CreateStartMenu()
    {
      GameObject startMenuGo = Instantiate(AssetPath.StartMenuPath);
      var startMenu = startMenuGo.GetComponent<StartMenu>();
      startMenu.Construct(_gameStateMachine);
    }

    private GameObject Instantiate(string prefabPath, Vector2 position, Quaternion rotation)
    {
      GameObject gameObject = _assets.Instantiate(prefabPath, position, rotation);
      return gameObject;
    }

    private GameObject Instantiate(string prefabPath, Vector2 position)
    {
      GameObject gameObject = _assets.Instantiate(prefabPath, position);
      return gameObject;
    }

    private GameObject Instantiate(string prefabPath)
    {
      GameObject gameObject = _assets.Instantiate(prefabPath);
      return gameObject;
    }
  }
}