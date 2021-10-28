using System;
using AlchemyCat.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace AlchemyCat.UI
{
  public class StartMenu : MonoBehaviour
  {
    private const string FirstLevel = "Level2";
    
    [SerializeField] private Button _playButton;
    private IGameStateMachine _gameStateMachine;
    
    public void Construct(IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
      _playButton.onClick.AddListener(StartGame);
    }

    private void StartGame() =>
      _gameStateMachine.Enter<LoadLevelState, string>(FirstLevel);

  }
}