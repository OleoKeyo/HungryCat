using AlchemyCat.Player;
using Logic;
using UnityEngine;

namespace ElementCrate
{
  public class Crate : MonoBehaviour, IInteractWithInventory
  {
    [SerializeField] private Element element;

    public void SetElement(ElementType generatedElement)
    {
      element.SetElement(generatedElement);
    }
    
    public void Interact(PlayerInventory inventory)
    {
      inventory.TakeElement(element);
    }
  }
}