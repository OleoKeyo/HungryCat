using UnityEngine;

namespace AlchemyCat.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider
  {
    public GameObject Instantiate(string path)
    {
      GameObject prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab);
    }

    public GameObject Instantiate(string path, Vector3 spawnPoint)
    {
      GameObject prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, spawnPoint, Quaternion.identity);
    }

    public GameObject Instantiate(string path, Vector3 spawnPoint, Quaternion quaternion)
    {
      GameObject prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, spawnPoint, quaternion);
    }
  }
}