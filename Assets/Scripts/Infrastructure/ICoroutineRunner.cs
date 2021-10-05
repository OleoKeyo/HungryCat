using System.Collections;
using UnityEngine;

namespace AlchemyCat.Infrastructure
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}