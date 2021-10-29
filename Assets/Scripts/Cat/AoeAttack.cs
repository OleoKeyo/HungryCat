using System.Collections;
using UnityEngine;

namespace AlchemyCat.Cat
{
  public class AoeAttack : MonoBehaviour, IAttack
  {
    public SpriteRenderer indicatorRenderer;
    public SpriteRenderer attackRenderer;
    public BoxCollider2D attackCollider;
    private ElementType _elementType = ElementType.Fire;
  
    private void Awake()
    {
      InstantFade();
      StartCoroutine(FadeOut());
    }

    private void InstantFade()
    {
      Color oldColor = indicatorRenderer.color;
      Color newColor = oldColor;
      newColor.a = 0f;
      indicatorRenderer.color = newColor;
    }

    private IEnumerator FadeOut()
    {
      while (indicatorRenderer.color.a < 1)
      {
        Color oldColor = indicatorRenderer.color;
        Color newColor = oldColor;
        newColor.a += 0.1f;
        indicatorRenderer.color = newColor;
        yield return new WaitForSeconds(0.05f);
      }
      StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
      while (indicatorRenderer.color.a > 0)
      {
        Color oldColor = indicatorRenderer.color;
        Color newColor = oldColor;
        newColor.a -= 0.1f;
        indicatorRenderer.color = newColor;
        yield return new WaitForSeconds(0.05f);
      }

      EnableAttackZone();
    }

    private void EnableAttackZone()
    {
      attackRenderer.enabled = true;
      attackCollider.enabled = true;
      StartCoroutine(DestroyTimer(2f));
    }
    
    private IEnumerator DestroyTimer(float timer)
    {
      yield return new WaitForSeconds(timer);
      Destroy(gameObject);
    }

    public ElementType GetElementType() =>
      _elementType;

  }
}