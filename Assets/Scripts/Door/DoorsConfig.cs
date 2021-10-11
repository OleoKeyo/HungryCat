using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorsConfig", menuName = "Doors")]
public class DoorsConfig : ScriptableObject
{
  public List<DoorData> doors;
}
