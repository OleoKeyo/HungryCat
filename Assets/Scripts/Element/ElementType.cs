public enum ElementType
{ 
    Fire = (1 << 0),
    Water = (1 << 1),
    Acid = (1 << 2),
    Air = Fire | Water,
    Oil = Fire | Acid,
    Lightning = Water | Acid
}
