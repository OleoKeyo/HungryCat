using UnityEngine;

namespace Config
{
  public class LevelTransferTrigger : MonoBehaviour
  {
    private const string PlayerTag = "Player";

    public int transferToIndexScene;
    private bool _triggered;
    private SceneLoadManager _sceneLoad;
    
    private void Start()
    {
      _sceneLoad = (SceneLoadManager) FindObjectOfType(typeof(SceneLoadManager));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(_triggered)
        return;

      if (other.CompareTag(PlayerTag))
      {
        _triggered = true;
        _sceneLoad.LoadScene(transferToIndexScene);
      }
    }
  }
}