using Logic;
using UnityEngine;

namespace ElementCrate
{
  public class TestAbility : MonoBehaviour, IInteractWithInventory
  {
    public ElementType elementType;
    
    private CatView _cat;
    public void Interact(PlayerInventory inventory)
    {
      if (_cat == null)
      {
        _cat = FindObjectOfType<CatView>();
      }
      _cat.ElementAttack(elementType);
    }
  }
}