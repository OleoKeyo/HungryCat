using System;
using UnityEngine;

namespace AlchemyCat.UI
{
  public class Tutorial : MonoBehaviour
  {
    public void Awake()
    {
      Time.timeScale = 0f;
    }

    private void Update()
    {
      if (Input.GetMouseButtonUp(0))
      {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
      }
    }
  }
}