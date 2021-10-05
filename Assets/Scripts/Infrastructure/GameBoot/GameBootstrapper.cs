using System;
using AlchemyCat.Infrastructure.SceneManagement;
using AlchemyCat.Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlchemyCat.Infrastructure.GameBoot
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    public LoadingCurtain CurtainPrefab;

    private Game _game;

    private void Awake()
    {
      _game = new Game(this, Instantiate(CurtainPrefab));
      string sceneName = SceneManager.GetActiveScene().name;
      _game.StateMachine.Enter<BootstrapState, string>(sceneName);
      
      DontDestroyOnLoad(this);
    }
  }
}