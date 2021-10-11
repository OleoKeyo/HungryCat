using AlchemyCat.Infrastructure.States;
using UnityEngine;

namespace Config
{
  public class LevelTransferTrigger : MonoBehaviour
  {
    private const string PlayerTag = "Player";

    public string TransferTo;
    private IGameStateMachine _stateMachine;
    private bool _triggered;
    
    public void Construct(IGameStateMachine stateMachine, string transferTo)
    {
      _stateMachine = stateMachine;
      TransferTo = transferTo;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (_triggered)
        return;

      if (other.CompareTag(PlayerTag))
      {
        Debug.Log("PlayerTrigger");
        _stateMachine.Enter<LoadLevelState, string>(TransferTo);
        _triggered = true;
      }
    }
  }
}