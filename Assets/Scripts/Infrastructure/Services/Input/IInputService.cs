using Infrastructure.Services.AllServices;
using UnityEngine;

namespace AlchemyCat.Services.Input
{
  public interface IInputService : IService
  {
    Vector2 Axis { get; }

    bool IsInteractButtonUp(); 
  }
}