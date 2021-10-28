using System;
using System.Collections.Generic;
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
    
    public void ElementAttack(ElementType elementType)
    {
        switch(elementType)
        {
            case ElementType.Fire:
                beamWeapon.EnableBeamAttack(elementType);
                break;
            case ElementType.Water:
                beamWeapon.EnableBeamAttack(elementType);
                break;
            case ElementType.Acid:
                beamWeapon.EnableBeamAttack(elementType);
                break;
            case ElementType.FireAcid:
                beamWeapon.EnableAoEAttack(elementType);
                break;
            case ElementType.FireWater:
                beamWeapon.EnableBubbleAttack(elementType);
                break;
            case ElementType.WaterAcid:
                beamWeapon.AddWaterAcidShoot();
                break;
        }
    }

    private void CombineAttack(List<Element> elements)
    {
        Element fire = elements.Find(x => x.ElementType.Equals(ElementType.Fire));
        Element water = elements.Find(x => x.ElementType.Equals(ElementType.Water));
        Element acid = elements.Find(x => x.ElementType.Equals(ElementType.Acid));

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
