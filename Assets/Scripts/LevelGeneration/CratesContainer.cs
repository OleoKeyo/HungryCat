using System.Collections.Generic;
using ElementCrate;
using UnityEngine;

namespace LevelGeneration
{
  public class CratesContainer : MonoBehaviour
  {
    public List<Crate> crates;

    public void SetElements(List<ElementType> generatedElements)
    {
      for (int x = 0; x < generatedElements.Count; x++)
      {
        crates[x].SetElement(generatedElements[x]);
      }
    }
  }
}