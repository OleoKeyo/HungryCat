using UnityEngine;

namespace AlchemyCat.StaticData
{
  [CreateAssetMenu(fileName = "DoorConfig", menuName = "Door")]
  public class DoorStaticData : ScriptableObject
  {
    public DoorData doorData;
  }
}