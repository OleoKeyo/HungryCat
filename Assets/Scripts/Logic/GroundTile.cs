using UnityEngine;
using UnityEngine.Tilemaps;

namespace Logic
{
  [CreateAssetMenu (fileName = "GroundTile", menuName = "Tile/GroundTile")]
  public class GroundTile : Tile
  {
    public TileType type;
  }
}