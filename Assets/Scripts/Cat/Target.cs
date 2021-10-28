using System;
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  
  private void Awake()
  {
    InstantFade();
    StartCoroutine(FadeOut());
  }

  private void InstantFade()
  {
    Color oldColor = spriteRenderer.color;
    Color newColor = oldColor;
    newColor.a = 0f;
    spriteRenderer.color = newColor;
  }

  private IEnumerator FadeIn()
  {
    while (spriteRenderer.color.a > 0)
    {
      Color oldColor = spriteRenderer.color;
      Color newColor = oldColor;
      newColor.a -= 0.1f;
      spriteRenderer.color = newColor;
      yield return new WaitForSeconds(0.05f);
    }
  }
  
  private IEnumerator FadeOut()
  {
    while (spriteRenderer.color.a < 1)
    {
      Color oldColor = spriteRenderer.color;
      Color newColor = oldColor;
      newColor.a += 0.1f;
      spriteRenderer.color = newColor;
      yield return new WaitForSeconds(0.05f);
    }
    StartCoroutine(FadeIn());
  }
}
