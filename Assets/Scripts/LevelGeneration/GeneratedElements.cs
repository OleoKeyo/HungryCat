using System.Collections.Generic;

namespace LevelGeneration
{
  public class GeneratedElements
  {
    public List<ElementType> elements = new List<ElementType>();
    public ElementType winnerType;

    public GeneratedElements(List<ElementType> elements, ElementType winner)
    {
      this.elements = elements;
      winnerType = winner;
    }
  }
}