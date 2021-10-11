using UnityEngine;

namespace AlchemyCat.Services.Input
{
  public abstract class InputService : IInputService
  {
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    private const string InteractButton = "Interact";

    public abstract Vector2 Axis { get; }

    public bool IsInteractButtonUp() =>
      SimpleInput.GetButton(InteractButton);

    protected static Vector2 SimpleInputAxis() =>
      new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
  }
}