using System;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public void EatElements(List<Element> inventoryElements)
    {
        if (inventoryElements.Count > 2) throw new Exception("more than 2 elements");
        if (inventoryElements.Count == 0) throw new Exception("elements not found");

        if (inventoryElements.Count == 1) ElementAttack(inventoryElements[0].ElementType);
        else CombineAttack(inventoryElements);
    }
    
    private void ElementAttack(ElementType elementType)
    {
        switch(elementType)
        {
            case ElementType.Fire:
                break;
            case ElementType.Water:
                break;
            case ElementType.Acid:
                break;
        }

        EventManager.OnIncorrectElementGivenEvent?.Invoke(transform);
    }

    private void CombineAttack(List<Element> elements)
    {
        var fire = elements.Find(x => x.ElementType.Equals(ElementType.Fire));
        var water = elements.Find(x => x.ElementType.Equals(ElementType.Water));
        var acid = elements.Find(x => x.ElementType.Equals(ElementType.Acid));

        if (fire && water)
        {
        }else if (fire && acid)
        {
        }else if (water && acid)
        {
        }
    }
}
