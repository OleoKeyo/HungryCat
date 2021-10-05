using System.Collections;
using DefaultNamespace.Player;
using ElementCrate;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _interactionRadius = 5f;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ElementInventory _inventory;

    [Header("Music")] 
    [SerializeField] private AudioClip getFlask;
    [SerializeField] private AudioClip dead;

    private AudioSource _audioSource;

    private InputController _inputController;
    
    void Awake()
    {
        _inputController = new InputController();
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void FixedUpdate()
    {
        Move();

        if (Input.GetKey(KeyCode.E))
            Interact();
    }

    private void Move()
    {
        _inputController.Update();
        Vector2 dir = new Vector2(_inputController.Horizontal, _inputController.Vertical);
        dir = dir.normalized;

        _rb.MovePosition(_rb.position + dir * _movementSpeed * Time.fixedDeltaTime);
        _playerAnimator.PlayerMove(dir);
    }

    private void Interact()
    {
        LayerMask mask = LayerMask.GetMask("Interactable");
        var collider = Physics2D.OverlapCircle(transform.position, _interactionRadius, mask);
        
        if (collider != null)
        {
            var elementContainer = collider.GetComponent<Crate>();
   
            if (elementContainer != null)
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
                cat.SetPlayer(this);
                cat.EatElements(_inventory.elements);
                _inventory.ClearInventory();
            }
        }
    }

    private void AddElement(Element element)
    {
        if (_inventory.elements.Count < 2 && !_inventory.elements.Contains(element))
        {
            _audioSource.clip = getFlask;
            _audioSource.Play();
            _inventory.AddElement(element);
        }
    }

    public void Dead()
    {
        StartCoroutine(DeadSound());
    }

    IEnumerator DeadSound()
    {
        _audioSource.clip = dead;
        _audioSource.Play();

        while (_audioSource.isPlaying) yield return new WaitForEndOfFrame();

        //FindObjectOfType<MainMenuControl>().OnGameOver();
        yield break;
    }
}
