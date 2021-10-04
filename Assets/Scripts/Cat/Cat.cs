using System.Collections.Generic;
using UnityEngine;


public class Cat : MonoBehaviour
{
    public BeamWeapon beamWeapon;
    
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
    }
    
    public void EatElements(List<Element> inventoryElements)
    {

    }
}
