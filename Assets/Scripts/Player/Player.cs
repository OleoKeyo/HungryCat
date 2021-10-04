using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Player;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _interactionRadius = 5f;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private InputController _inputController;
    private ElementInventory _inventory;


    void Start()
    {
        _inputController = new InputController();
        _inventory = new ElementInventory();
    }
    
    private void FixedUpdate()
    {
        _inputController.Update();
        Vector2 dir = new Vector2(_inputController.Horizontal, _inputController.Vertical);
        dir = dir.normalized;
        
        _rb.MovePosition(_rb.position + dir * _movementSpeed * Time.fixedDeltaTime);
        _playerAnimator.PlayerMove(dir);
    }

   // private void Interact()
   // {
   //     LayerMask mask = LayerMask.GetMask("Interactable");
   //     var collider = Physics2D.OverlapCircle(transform.position, _interactionRadius, mask);
   //     
   //     if (collider != null)
   //     {
   //         var elementContainer = collider.GetComponent<ElementContainer>();
   //
   //         if (elementContainer.element != null)
   //         {
   //             AddElement(elementContainer); // Добавляем элемент в "инвентарь"
   //         }
   //     }
   //
   //     TryToSpendElements(); // Проверяем можно ли сдать элементы кошке
   // }

   // private void TryToSpendElements()
   // {
   //     if (_inventory.elements.Count > 0)
   //     {
   //         ElementType resultElement = 0;
   // 
   //         foreach (var item in _inventory.elements)
   //         {
   //             resultElement |= item.elementType;
   //         }
   //
   //         LayerMask catMask = LayerMask.GetMask("Cat");
   //         var collider = Physics2D.OverlapCircle(transform.position, _interactionRadius, catMask);

   //  if (collider != null)
   //         {
   //             EventManager.OnCatInteractEvent?.Invoke(resultElement);
   //         }
   //     }
   // }

   // private void AddElement(ElementContainer elementContainer)
   // {
   //     if (_inventory.elements.Count < 2)
   //     {
   //         _inventory.elements.Add(elementContainer.element);
   //         EventManager.OnElementAddToInventoryEvent?.Invoke(elementContainer.element.elementSprite);
   //     }
   // }
}
