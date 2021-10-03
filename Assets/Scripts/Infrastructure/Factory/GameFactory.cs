using Infrastructure.AssetManagement;
using Infrastructure.Input;
using UnityEngine;

namespace Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private IAssetProvider _assets;
    private IInputService _inputService;

    public GameFactory(IAssetProvider assets, IInputService inputService)
    {
      _assets = assets;
      _inputService = inputService;
    }
    
    private GameObject Instantiate(string prefabPath, Vector3 position)
    {
      GameObject gameObject = _assets.Instantiate(prefabPath, position);
      return gameObject;
    }

    private GameObject Instantiate(string prefabPath)
    {
      GameObject gameObject = _assets.Instantiate(prefabPath);
      return gameObject;
    }

    public Player CreatePlayer(Vector3 position)
    {
      GameObject playerGo = Instantiate(AssetPath.PlayerPath, position);
      Player player = playerGo.GetComponent<Player>();
      return player;
    }

    public void CreateCat(Vector3 position)
    {
    }
  }
}