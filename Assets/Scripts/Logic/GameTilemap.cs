using System.Collections.Generic;
using AlchemyCat.StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Logic
{
  public class GameTilemap : MonoBehaviour
  {
    public Tilemap floorTilemap;
    private bool[,] _walkableMap;
    private Vector3Int _mapSize;
    private Vector3Int _offset;

    public void Construct(LevelStaticData levelData)
    {
      InitWalkableMap(levelData);
    }

    private void InitWalkableMap(LevelStaticData levelData)
    {
      _mapSize = floorTilemap.size;
      _offset = floorTilemap.origin;
      
      _walkableMap = new bool[_mapSize.x, _mapSize.y];

      for (int x = _offset.x; x < _mapSize.x; x++)
      {
        for (int y = _offset.y; y < _mapSize.y; y++)
        {
          Vector3Int tilePos = new Vector3Int(x, y, 0);
          TileBase tile = floorTilemap.GetTile(tilePos);

          if (tile != null)
            _walkableMap[tilePos.x - _offset.x, tilePos.y - _offset.y] = true;
        }
      }

      foreach (MapObjectData mapObject in levelData.mapObjects)
      {
        OccupyFloor(mapObject);
      }
    }

    private void OccupyFloor(MapObjectData mapObject)
    {
      for (int xSize = 0; xSize < mapObject.size.x; xSize++)
      {
        for (int ySize = 0; ySize < mapObject.size.y; ySize++)
        {
          Vector3 pos = new Vector3(mapObject.position.x + xSize, mapObject.position.y + ySize, 0);
          Vector3Int cellPos = floorTilemap.WorldToCell(pos);
          _walkableMap[cellPos.x - _offset.x, cellPos.y - _offset.y] = false;
        }
      }
    }

    public List<Vector3> GetFreeRandomPoints(Vector3 playerPosition, int radius, int count)
    {
      List<Vector3> freePoints = new List<Vector3>();
      Vector3Int playerCellPosition = floorTilemap.WorldToCell(playerPosition);

      for (int x = playerCellPosition.x - radius; x <= playerPosition.x + radius; x++)
      {
        for (int y = playerCellPosition.y - radius; y <= playerCellPosition.y + radius; y++)
        {
          var cellPos = new Vector3Int(x, y, 0);
          if(CellIsWalkable(cellPos))
            freePoints.Add(floorTilemap.GetCellCenterWorld(cellPos));
        }
      }

      int neededPoints = count;
      List<Vector3> result = new List<Vector3>();

      while (neededPoints > 0)
      {
        if (freePoints.Count == 0)
        {
          neededPoints = 0;
          break;
        }
        
        int randomIndex = Random.Range(0, freePoints.Count);
        Vector3 randomPoint = freePoints[randomIndex];
        
        result.Add(randomPoint);
        freePoints.Remove(randomPoint);
        
        neededPoints--;
      }

      return result;
    }

    private bool CellIsWalkable(Vector3Int cellPos)
    {
      int xPos = cellPos.x - _offset.x;
      int yPos = cellPos.y - _offset.y;
      
      if (xPos < 0 || xPos > _mapSize.x || yPos < 0 || yPos > _mapSize.y)
        return false;
      
      return _walkableMap[xPos, yPos];
    }
  }
}