using System.Collections;
using UnityEngine;

namespace AlchemyCat.Infrastructure.SceneManagement
{
  public class LoadingCurtain : MonoBehaviour
  {
    public CanvasGroup curtain;
    private Coroutine _fadeCoroutine;
    
    public void Show()
    {
      StopPreviousFade();
      gameObject.SetActive(true);
      _fadeCoroutine = StartCoroutine(DoFadeOut());
    }

    public void Hide()
    {
      StopPreviousFade();
      _fadeCoroutine = StartCoroutine(DoFadeIn());
    }

    private void Awake()
    {
      DontDestroyOnLoad(this);
    }

    private void Start()
    {
      curtain.alpha = 1;
    }

    private void StopPreviousFade()
    {
      if (_fadeCoroutine != null)
      {
        StopCoroutine(_fadeCoroutine);
      }
    }

    private IEnumerator DoFadeIn()
    {
      while (curtain.alpha > 0)
      {
        curtain.alpha -= 0.03f;
        yield return new WaitForSecondsRealtime(0.03f);
      }
      gameObject.SetActive(false);
    }
    
    private IEnumerator DoFadeOut()
    {
      while (curtain.alpha < 1)
      {
        curtain.alpha += 0.03f;
        yield return new WaitForSecondsRealtime(0.03f);
      }
    }
  }
}