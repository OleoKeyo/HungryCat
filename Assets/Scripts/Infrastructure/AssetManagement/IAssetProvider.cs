using Infrastructure.Services.AllServices;
using UnityEngine;

namespace AlchemyCat.Infrastructure.AssetManagement
{
  public interface IAssetProvider : IService
  {
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 spawnPoint);
  }
}