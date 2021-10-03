using UnityEngine;

namespace Infrastructure.Input
{
  public abstract class InputService : IInputService
  {
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    private const string ActionButton = "E";
    
    public abstract Vector2 Axis { get; }

    public bool IsActionButtonUp() =>
      SimpleInput.GetButtonUp(ActionButton);
    
    protected static Vector2 SimpleInputAxis() =>
      new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
  }
}