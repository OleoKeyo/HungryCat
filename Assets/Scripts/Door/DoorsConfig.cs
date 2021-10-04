using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorsConfig", menuName = "Doors")]
public class DoorsConfig : ScriptableObject
{
  public List<DoorData> doors;
  private Dictionary<ElementType, DoorData> dataByType;
  
  public Sprite GetDoorSprite(ElementType elementType)
  {
    if (dataByType == null)
    {
      CollectData();
    }
    return dataByType[elementType].sprite;
  }

  private void CollectData()
  {
    dataByType = new Dictionary<ElementType, DoorData>();
    foreach (DoorData door in doors)
    {
      dataByType[door.rightElementForOpen] = door;
    }
  }
}
