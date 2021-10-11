using System;
using DefaultNamespace.Player;
using Logic;
using UnityEngine;

namespace AlchemyCat.Player
{
  [RequireComponent(typeof(PlayerAnimator))]
  public class PlayerHealth : MonoBehaviour, IHealth
  {
    private PlayerAnimator _animator;

    public int Health
    {
      get => _health;
      set
      {
        if (_health != value)
        {
          _health = value;
          HealthChanged?.Invoke();
        }
      }
    }
    
    private int _health;

    public event Action HealthChanged;

    private void Awake()
    {
      _animator = GetComponent<PlayerAnimator>();
    }

    public void TakeDamage(ElementType elementType)
    {
      if(Health <= 0)
        return;

      Health -= 1;
      _animator.PlayHit();
    }
  }
}