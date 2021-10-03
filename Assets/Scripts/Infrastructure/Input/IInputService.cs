using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Input
{
  public interface IInputService : IService
  {
    Vector2 Axis { get; }

    bool IsActionButtonUp();
  }
}