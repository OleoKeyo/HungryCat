using System;
using System.Collections.Generic;
using AlchemyCat.Cat;
using Logic;
using UnityEngine;


public class CatView : MonoBehaviour, IInteractWithInventory
{
    public RayShootWeapon rayShootWeapon;
    public AoeWeapon aoeWeapon;
    public BeamWeapon beamWeapon;
    public BubbleAttackWeapon bubbleAttackWeapon;

    public void Construct(Transform playerTransform, GameTilemap gameTilemap)
    {
        rayShootWeapon.Construct(playerTransform);
        aoeWeapon.Construct(playerTransform);
        beamWeapon.Construct(playerTransform);
        bubbleAttackWeapon.Construct(playerTransform, gameTilemap);
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
                aoeWeapon.EnableAoEAttack(elementType);
                break;
            case ElementType.FireWater:
                bubbleAttackWeapon.EnableBubbleAttack(elementType);
                break;
            case ElementType.WaterAcid:
                rayShootWeapon.EnableShoot();
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
        }
        else if (fire && acid)
        {
        }
        else if (water && acid)
        {
        }
    }
    
    public void Interact(PlayerInventory inventory)
    {
        Debug.Log("Cat interact");
        EatElements(inventory.elements);
        inventory.ClearInventory();
    }
}
