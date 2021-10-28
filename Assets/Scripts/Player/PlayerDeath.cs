using System;
using AlchemyCat.Infrastructure.States;
using DefaultNamespace.Player;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlchemyCat.Player
{
  [RequireComponent(typeof(PlayerHealth))]
  [RequireComponent(typeof(PlayerMove))]
  [RequireComponent(typeof(PlayerAnimator))]
  [RequireComponent(typeof(PlayerAudio))]
  public class PlayerDeath: MonoBehaviour
  {
    private PlayerHealth _health;
    private PlayerMove _move;
    private PlayerAnimator _animator;
    private PlayerAudio _audio;
    
    private bool _isDead;
    private IGameStateMachine _stateMachine;

    private void Awake()
    {
      _health = GetComponent<PlayerHealth>();
      _move = GetComponent<PlayerMove>();
      _animator = GetComponent<PlayerAnimator>();
      _audio = GetComponent<PlayerAudio>();
    }

    public void Construct(IGameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    private void Start() =>
      _health.HealthChanged += HealthChanged;
    

    private void OnDestroy() =>
      _health.HealthChanged -= HealthChanged;
    
    private void HealthChanged()
    {
      if(!_isDead && _health.Health <= 0)
        Die();   
    }

    private void Die()
    {
      _isDead = true;
      _move.enabled = false;
      _animator.PlayDeath();
      _audio.PlayDeath();
      string levelKey = SceneManager.GetActiveScene().name;
      _stateMachine.Enter<LoadLevelState, string>(levelKey);
    }
  }
}