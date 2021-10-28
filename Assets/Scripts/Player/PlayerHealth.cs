using System;
using AlchemyCat.Cat;
using DefaultNamespace.Player;
using Logic;
using UnityEngine;

namespace AlchemyCat.Player
{
  [RequireComponent(typeof(PlayerAnimator))]
  public class PlayerHealth : MonoBehaviour, IHealth
  {
    private PlayerAnimator _animator;

    public int maxHealth;

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
      Health = maxHealth;
    }

    public void TakeDamage(ElementType elementType)
    {
      if(Health <= 0)
        return;

      Health -= 1;
      _animator.PlayHit();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
      IAttack attack = other.GetComponent<IAttack>();
      if (attack != null)
      {
        Debug.Log("PlayerHit");
        ElementType element = attack.GetElementType();
        TakeDamage(element);
      }
    }
  }
}