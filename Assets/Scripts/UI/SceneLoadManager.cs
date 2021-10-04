using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Image blackWindow;
    private int _currentSceneNumber;
    private float _stepSec = 0.5f;
    private bool _isLoading;

    private void Awake()
    {
        ChangeAlphaForBlack(0);
        _isLoading = false;
        _currentSceneNumber = -1;
    }

    public void LoadScene(int sceneNumber)
    {
        if (sceneNumber == -5)
        {
            FindObjectOfType<MainMenuControl>().OnCatPanel();
            return;
        }

        if(!_isLoading){
            _isLoading = true;
            if (_currentSceneNumber != -1) SceneManager.UnloadSceneAsync(_currentSceneNumber);
            
            _currentSceneNumber = sceneNumber;
            var loader = SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Additive);

            StartCoroutine(Loading(loader));
        }
    }
    
    public void UnloadCurrentScene()
    {
        if (_currentSceneNumber != -1) SceneManager.UnloadSceneAsync(_currentSceneNumber);
        _currentSceneNumber = -1;
    }

    IEnumerator Loading(AsyncOperation operation)
    {
        var al = 0f;
        var step = 0.01f;
        while (true)
        {
            var progress = operation.progress;
            
            if (progress < 0.5f) al += step;
            else al -= step;
            
            al = Mathf.Clamp(al, 0f, 1f);
            ChangeAlphaForBlack(al);

            if (al == 0f)
            {
                _isLoading = false;
                yield break;
            }
            yield return new WaitForSeconds(_stepSec);
        }
    }

    private void ChangeAlphaForBlack(float alpha)
    {
        var c = blackWindow.color;
        c.a = alpha;
        blackWindow.color = c;
    }
}
