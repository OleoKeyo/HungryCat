using System;

[Flags]
public enum ElementType
{
    Unknown = 0,
    Fire = 1,
    Water = 2,
    Acid = 4,
    FireWater = Fire | Water,
    FireAcid = Fire | Acid,
    WaterAcid = Water| Acid
}
