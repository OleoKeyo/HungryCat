using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Logic
{
  public class TilemapTest : MonoBehaviour
  {
    private Tilemap _tilemap;
    public GroundTile testTile;

    private void Awake()
    {
      _tilemap = GetComponent<Tilemap>();
      
      Debug.Log($"Size: {_tilemap.size}");
      Debug.Log($"Origin: {_tilemap.origin}");
      Debug.Log($"CellBounds: {_tilemap.cellBounds}");
      Debug.Log($"LocalBounds: {_tilemap.localBounds}");
      
      _tilemap.SetTile(_tilemap.origin, testTile);
      var tile = (GroundTile) _tilemap.GetTile(_tilemap.origin);
      Debug.Log($"tileName: {tile.name} myInt: {tile.MyInt}");
    }
  }
}