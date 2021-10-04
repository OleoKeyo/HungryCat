using UnityEngine;
using UnityEngine.SceneManagement;

namespace Config
{
  public class LevelTransferTrigger : MonoBehaviour
  {
    private const string PlayerTag = "Player";

    public string transferTo;
    private bool _triggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(_triggered)
        return;

      if (other.CompareTag(PlayerTag))
      {
        _triggered = true;
        SceneManager.LoadScene(transferTo);
      }
    }
  }
}