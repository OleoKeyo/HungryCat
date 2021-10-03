using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _interactionRadius = 5f;

    private InputController _inputConatroller;
    private ElementInventory _inventory;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputConatroller = new InputController();
        _inventory = new ElementInventory();
        EventManager.TryToInteractEvent += Interact;
    }

    void Update()
    {
        _inputConatroller.Update();
    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(_inputConatroller.Horizontal, _inputConatroller.Vertical);
        dir = dir.normalized;
        _rb.MovePosition(_rb.position + dir * _movementSpeed * Time.fixedDeltaTime);
    }

    private void Interact()
    {
        LayerMask mask = LayerMask.GetMask("Interactable");
        var collider = Physics2D.OverlapCircle(transform.position, _interactionRadius, mask);
        
        if (collider != null)
        {
            var elementContainer = collider.GetComponent<ElementContainer>();

            if (elementContainer.element != null)
            {
                AddElement(elementContainer); // Добавляем элемент в "инвентарь"
            }
        }

        TryToSpendElements(); // Проверяем можно ли сдать элементы кошке
    }

    private void TryToSpendElements()
    {
        if (_inventory.elements.Count > 0)
        {
            ElementType resultElement = 0;

            foreach (var item in _inventory.elements)
            {
                resultElement |= item.elementType;
            }

            LayerMask catMask = LayerMask.GetMask("Cat");
            var collider = Physics2D.OverlapCircle(transform.position, _interactionRadius, catMask);

            if (collider != null)
            {
                EventManager.OnCatInteractEvent?.Invoke(resultElement);
            }
        }
    }

    private void AddElement(ElementContainer elementContainer)
    {
        if (_inventory.elements.Count < 2)
        {
            _inventory.elements.Add(elementContainer.element);
            EventManager.OnElementAddToInventoryEvent?.Invoke(elementContainer.element.elementSprite);
        }
    }

    private void OnDisable()
    {
        EventManager.TryToInteractEvent -= Interact;
    }
}
