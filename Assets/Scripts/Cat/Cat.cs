using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cat : MonoBehaviour
{
    private void CheckElement(ElementType elementType)
    {
        switch(elementType)
        {
            case ElementType.Fire:
                break;
            case ElementType.Water:
                break;
            case ElementType.FireAcid:
                break;
        }

        EventManager.OnIncorrectElementGivenEvent?.Invoke(transform);
    }

    private void OnDisable()
    {
    }

    public void EatElements(List<Element> inventoryElements)
    {
       
    }
}
