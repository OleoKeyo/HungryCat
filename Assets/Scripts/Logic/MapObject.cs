using UnityEngine;

namespace Logic
{
  public class MapObject : MonoBehaviour
  {
    public Vector2Int size;
    public SpriteRenderer spriteRenderer;
    
    public Vector3 MinBounds => spriteRenderer.sprite.bounds.min;
  }
}