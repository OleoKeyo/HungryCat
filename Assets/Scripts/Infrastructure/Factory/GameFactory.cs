using AlchemyCat.Infrastructure.AssetManagement;
using AlchemyCat.Services.Input;
using UnityEngine;

namespace AlchemyCat.Infrastructure.Factory
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

    public GameObject CreatePlayer(Vector2 at)
    {
      return Instantiate(AssetPath.PlayerPath, at);
    }

    public GameObject CreateCat(Vector2 at)
    {
      return Instantiate(AssetPath.CatPath, at);
    }

    public GameObject CreateCrate(Vector2 at)
    {
      return Instantiate(AssetPath.CatPath, at);
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