using System;
using System.Collections;
using UnityEngine;

namespace AlchemyCat.Cat
{
  public class RayAttackIndicator : MonoBehaviour
  {
    public RayAttack rayAttack;
    
    private Transform _transform;
    
    private void Awake()
    {
      _transform = GetComponent<Transform>();
      StartCoroutine(ScaleUpThenActivateRay(new Vector3(3f, 5f, 0f), 1f));
    }
    
    private IEnumerator ScaleUpThenActivateRay(Vector3 upScale, float duration)
    {
      Vector3 initialScale = _transform.localScale;
 
      for(float time = 0 ; time < duration; time += Time.deltaTime)
      {
        float progress = time / duration;
        _transform.localScale = Vector3.Lerp(initialScale, upScale, progress);
        yield return null;
      }

      ActivateRay();
    }

    private void ActivateRay()
    {
      gameObject.SetActive(false);
      rayAttack.gameObject.SetActive(true);
    }
  }
}