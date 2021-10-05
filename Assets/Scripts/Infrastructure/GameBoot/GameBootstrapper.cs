using System;
using AlchemyCat.Infrastructure.SceneManagement;
using AlchemyCat.Infrastructure.States;
using UnityEngine;

namespace AlchemyCat.Infrastructure.GameBoot
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    public LoadingCurtain CurtainPrefab;

    private Game _game;

    private void Awake()
    {
      _game = new Game(this, Instantiate(CurtainPrefab));
      _game.StateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(this);
    }
  }
}