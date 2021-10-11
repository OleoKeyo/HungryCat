using System;

namespace Logic
{
  public interface IHealth
  {
    int Health { get; set; }
    event Action HealthChanged;
    void TakeDamage(ElementType elementType);
  }
}