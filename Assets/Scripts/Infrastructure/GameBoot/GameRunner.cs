using UnityEngine;

namespace AlchemyCat.Infrastructure.GameBoot
{
  public class GameRunner : MonoBehaviour
  {
    public GameBootstrapper BootstrapperPrefab;
    private void Awake()
    {
      GameBootstrapper bootstrapper = FindObjectOfType<GameBootstrapper>();

      if (!bootstrapper)
      {
        Instantiate(BootstrapperPrefab);
      }
    }
  }
}