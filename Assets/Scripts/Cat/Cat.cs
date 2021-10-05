using System;
using System.Collections.Generic;
using UnityEngine;


public class Cat : MonoBehaviour
{
    public BeamWeapon beamWeapon;

    private PlayerView _player;
    
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

    public void SetPlayer(PlayerView player)
    {
        if(_player!=null)
            return;
        _player = player;
        beamWeapon.SetPlayer(player);
    }
}
