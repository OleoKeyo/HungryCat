using System;
using AlchemyCat.Services.Input;
using DefaultNamespace.Player;
using Logic;
using SimpleInputNamespace;
using UnityEngine;

namespace AlchemyCat.Player
{
  [RequireComponent(typeof(PlayerAudio))]
  [RequireComponent(typeof(PlayerInventory))]
  [RequireComponent(typeof(ButtonInputKeyboard))]
  public class PlayerInteract : MonoBehaviour
  {
    private const string InteractLayerName = "Interact";
    
    [SerializeField] private float interactionRadius = 0.5f;
    [SerializeField] private ButtonInputKeyboard interactButton;

    private PlayerInventory _inventory;
    private IInputService _inputService;
    private LayerMask _interactMask;
    private DateTime _lastInteract;
    private float _interactCooldown = 0.5f;

    private void Awake()
    {
      _inventory = GetComponent<PlayerInventory>();
      _interactMask = LayerMask.GetMask(InteractLayerName);
    }

    public void Construct(IInputService inputService) =>
      _inputService = inputService;

    private void FixedUpdate()
    {
      if (_inputService.IsInteractButtonUp())
        Interact();
    }
    
    private void Interact()
    {
      Collider2D overlapCircle = Physics2D.OverlapCircle(transform.position, interactionRadius, _interactMask);
      if (overlapCircle != null)
      {
        if (DateTime.Now - _lastInteract < TimeSpan.FromSeconds(_interactCooldown))
          return;
        
        _lastInteract = DateTime.Now;
        IInteractWithInventory interactWithInventory = overlapCircle.GetComponent<IInteractWithInventory>();
        interactWithInventory?.Interact(_inventory);
      }
    }
  }
}