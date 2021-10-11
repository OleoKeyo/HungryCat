using System;
using System.Collections.Generic;
using AlchemyCat.Player;
using Logic;
using UnityEngine;


public class CatView : MonoBehaviour, IInteractWithInventory
{
    public BeamWeapon beamWeapon;

    public void Construct(Transform playerTransform)
    {
        beamWeapon.Construct(playerTransform);
    }

    public void EatElements(List<Element> inventoryElements)
    {
        if (inventoryElements.Count == 0) return;
        if (inventoryElements.Count > 2) throw new Exception("more than 2 elements");

        if (inventoryElements.Count == 1) ElementAttack(inventoryElements[0].ElementType);
        else CombineAttack(inventoryElements);
    }
    
    private void ElementAttack(ElementType elementType)
    {
        switch(elementType)
        {
            case ElementType.Fire:
                beamWeapon.EnableFireBeam();
                break;
            case ElementType.Water:
                beamWeapon.EnableWaterBeam();
                break;
            case ElementType.Acid:
                beamWeapon.EnableAcidBeam();
                break;
        }
    }

    private void CombineAttack(List<Element> elements)
    {
        var fire = elements.Find(x => x.ElementType.Equals(ElementType.Fire));
        var water = elements.Find(x => x.ElementType.Equals(ElementType.Water));
        var acid = elements.Find(x => x.ElementType.Equals(ElementType.Acid));

        if (fire && water)
        {
            beamWeapon.AddFireWaterShoot();
        }
        else if (fire && acid)
        {
            beamWeapon.AddFireAcidShoot();
        }
        else if (water && acid)
        {
            beamWeapon.AddWaterAcidShoot();
        }
    }
    
    public void Interact(PlayerInventory inventory)
    {
        Debug.Log("Cat interact");
        EatElements(inventory.elements);
        inventory.ClearInventory();
    }
}
