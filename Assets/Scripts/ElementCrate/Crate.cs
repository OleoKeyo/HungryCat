using UnityEngine;

namespace ElementCrate
{
  public class Crate : MonoBehaviour
  {
    public Element element;

    public void SetElement(ElementType generatedElement)
    {
      element.SetElement(generatedElement);
    }
  }
}