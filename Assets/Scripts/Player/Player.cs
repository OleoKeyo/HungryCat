using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Player;
using ElementCrate;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _interactionRadius = 5f;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ElementInventory _inventory;

    private InputController _inputController;
    
    void Awake()
    {
        _inputController = new InputController();
    }
    
    private void FixedUpdate()
    {
        _inputController.Update();
        Vector2 dir = new Vector2(_inputController.Horizontal, _inputController.Vertical);
        dir = dir.normalized;
        
        _rb.MovePosition(_rb.position + dir * _movementSpeed * Time.fixedDeltaTime);
        _playerAnimator.PlayerMove(dir);
        
        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    private void Interact()
    {
        LayerMask mask = LayerMask.GetMask("Interactable");
        var collider = Physics2D.OverlapCircle(transform.position, _interactionRadius, mask);
        
        if (collider != null)
        {
            var elementContainer = collider.GetComponent<Crate>();
   
            if (elementContainer.element != null)
            {
                AddElement(elementContainer.element);
            }
        }
   
        TryToSpendElements(); 
    }

    private void TryToSpendElements()
    {
        if (_inventory.elements.Count > 0)
        {
            LayerMask catMask = LayerMask.GetMask("Cat");
            var collider = Physics2D.OverlapCircle(transform.position, _interactionRadius, catMask);

            if (collider != null)
            {
                var cat = collider.GetComponent<Cat>();
                cat.EatElements(_inventory.elements);
            }
        }
    }

    private void AddElement(Element element)
    {
        if (_inventory.elements.Count < 2)
        {
            _inventory.AddElement(element);
        }
    }
}
