using System;
using System.Runtime.CompilerServices;
using AlchemyCat.Services.Input;
using DefaultNamespace.Player;
using Logic;
using UnityEngine;

namespace Player
{
  [RequireComponent(typeof(Rigidbody2D))]
  [RequireComponent(typeof(PlayerAnimator))]
  public class PlayerMove : MonoBehaviour
  {
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody2D _rb;
    private PlayerAnimator playerAnimator;
    private IInputService _inputService;

    public void Construct(IInputService inputService)
    {
      _inputService = inputService;
      _rb = GetComponent<Rigidbody2D>();
      playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
      Move();
    }

    private void Move()
    {
      Vector2 dir = _inputService.Axis;
      dir.Normalize();
      _rb.MovePosition(_rb.position + dir * movementSpeed * Time.fixedDeltaTime);
      playerAnimator.PlayerMove(dir);
    }
  }
}