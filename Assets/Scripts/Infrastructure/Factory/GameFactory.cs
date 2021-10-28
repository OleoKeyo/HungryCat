using System.Linq.Expressions;
using AlchemyCat.Infrastructure.AssetManagement;
using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.Infrastructure.States;
using AlchemyCat.Player;
using AlchemyCat.Services.Input;
using AlchemyCat.UI;
using Config;
using ElementCrate;
using Player;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssetProvider _assets;
    private readonly IInputService _inputService;
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IStaticDataService _staticDataService;

    private GameObject _playerGameObject { get; set; }

    public GameFactory(
      IAssetProvider assets, 
      IInputService inputService, 
      IGameStateMachine gameStateMachine, 
      IStaticDataService staticDataService)
    {
      _assets = assets;
      _inputService = inputService;
      _gameStateMachine = gameStateMachine;
      _staticDataService = staticDataService;
    }

    public GameObject CreatePlayer(Vector2 at)
    {
      _playerGameObject  = Instantiate(AssetPath.PlayerPath, at);
      PlayerMove playerMove = _playerGameObject .GetComponent<PlayerMove>();
      playerMove.Construct(_inputService);
      PlayerInteract playerInteruct = _playerGameObject.GetComponent<PlayerInteract>();
      playerInteruct.Construct(_inputService);
      PlayerDeath playerDeath = _playerGameObject.GetComponent<PlayerDeath>();
      playerDeath.Construct(_gameStateMachine);
      return _playerGameObject ;
    }

    public GameObject CreateCat(Vector2 at)
    {
      GameObject catGO = Instantiate(AssetPath.CatPath, at);
      CatView cat = catGO.GetComponent<CatView>();
      cat.Construct(_playerGameObject.transform);

      return catGO;
    }

    public GameObject CreateDoor(
      Vector2 at, 
      LevelTransferData levelTransferData,
      ElementType doorType)
    {
      DoorData doorData = _staticDataService.ForDoor(doorType);
      GameObject doorGo = Instantiate(AssetPath.DoorPath, at);
      DoorView doorView = doorGo.GetComponent<DoorView>();
      doorView.Construct(levelTransferData, this, doorType, doorData.sprite);
      DoorAudio audio = doorGo.GetComponent<DoorAudio>();
      audio.Construct(doorData.successSound, doorData.failSound);
      return doorGo;
    }

    public GameObject CreateLevelTransformTrigger(LevelTransferData transferData)
    {
      GameObject levelTransferGo = Instantiate(AssetPath.LevelTransformTrigger, transferData.position, transferData.rotation);
      LevelTransferTrigger transferTrigger = levelTransferGo.GetComponent<LevelTransferTrigger>();
      transferTrigger.Construct(_gameStateMachine, transferData.transferTo);
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

    private GameObject Instantiate(string prefabPath, Vector2 position, Quaternion rotation) => 
      _assets.Instantiate(prefabPath, position, rotation);
    
    private GameObject Instantiate(string prefabPath, Vector2 position) =>
      _assets.Instantiate(prefabPath, position);
    
    private GameObject Instantiate(string prefabPath) =>
      _assets.Instantiate(prefabPath);
  
  }
}