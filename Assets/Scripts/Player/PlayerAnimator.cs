using System;
using Logic;
using UnityEngine;

namespace DefaultNamespace.Player
{
  public class PlayerAnimator : MonoBehaviour, IAnimationStateReader
  {
    private static readonly int IdleHash = Animator.StringToHash("IdleObjects");
    private static readonly int IdleWithObjectsHash = Animator.StringToHash("IdleWithObjects");
    private static readonly int GrabGiveHash = Animator.StringToHash("GrabGive");
    private static readonly int MoveHash = Animator.StringToHash("Move");
    private static readonly int MoveWithOneObjectHash = Animator.StringToHash("MoveWithOneObject");
    private static readonly int MoveWithTwoObjects = Animator.StringToHash("MoveWithTwoObjects");

    private readonly int _idleStateHash = Animator.StringToHash("Idle");
    private readonly int _idleWithObjectsStateHash = Animator.StringToHash("IdleWithObjects");
    private readonly int _grabGiveStateHash = Animator.StringToHash("GrabGive");
    private readonly int _moveStateHash = Animator.StringToHash("Move");
    private readonly int _moveWithOneObjectStateHash = Animator.StringToHash("MoveWithOneObject");
    private readonly int _moveWithTwoObjectsStateHash = Animator.StringToHash("MoveWithTwoObjects");
    
    public event Action<AnimatorState> StateEntered;
    public event Action<AnimatorState> StateExited;

    public AnimatorState State { get; private set; }
    
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public void PlayerMove(Vector2 dir)
    {
      animator.SetFloat(MoveHash, dir.magnitude, 0.1f, Time.deltaTime);
      if (!spriteRenderer.flipX && dir.x < 0)
      {
        spriteRenderer.flipX = true;
      }
      if (spriteRenderer.flipX && dir.x > 0)
      {
        spriteRenderer.flipX = false;
      }
    }

    public void GrabItem() => animator.SetBool(GrabGiveHash, true);
    
    public void GiveItem() => animator.SetBool(GrabGiveHash, false);
    
    public void EnteredState(int stateHash)
    {
      State = StateFor(stateHash);
      StateEntered?.Invoke(State);
    }

    public void ExitedState(int stateHash) =>
      StateExited?.Invoke(StateFor(stateHash));
    
    private AnimatorState StateFor(int stateHash)
    {
      AnimatorState state;
      if (stateHash == _idleStateHash)
        state = AnimatorState.Idle;
      else if (stateHash == _idleWithObjectsStateHash)
        state = AnimatorState.IdleWithObjects;
      else if (stateHash == _grabGiveStateHash)
        state = AnimatorState.GrabGive;
      else if (stateHash == _moveStateHash)
        state = AnimatorState.Move;
      else if (stateHash == _moveWithOneObjectStateHash)
        state = AnimatorState.MoveWithOneObject;      
      else if (stateHash == _moveWithTwoObjectsStateHash)
        state = AnimatorState.MoveWithTwoObjects;
      else
        state = AnimatorState.Unknown;
      
      return state;
    }
    
  }
}