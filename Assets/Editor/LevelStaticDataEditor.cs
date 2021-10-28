using System.Collections.Generic;
using System.Linq;
using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.SpawnMarkers;
using AlchemyCat.StaticData;
using Logic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlchemyCat.Editor
{
  [CustomEditor(typeof(LevelStaticData))]
  public class LevelStaticDataEditor : UnityEditor.Editor
  {
    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();
      LevelStaticData levelData = (LevelStaticData)target;

      if (GUILayout.Button("Collect"))
      {
        levelData.levelKey = SceneManager.GetActiveScene().name;
        
        levelData.crateSpawnerPositions =
          FindObjectsOfType<CrateSpawnMarker>()
            .Select(x => (Vector2) x.GetComponent<Transform>().position)
            .ToList();

        levelData.catPosition = FindObjectOfType<CatSpawnMarker>().GetComponent<Transform>().position;
        levelData.doorData = CollectDoorStaticData();
        levelData.levelTransferData = CollectLevelTransferData();
        levelData.initialPlayerPosition = FindObjectOfType<PlayerSpawnMarker>().GetComponent<Transform>().position;
        levelData.mapObjects = CollectMapObjects();
      }
      
      EditorUtility.SetDirty(target);
    }

    private List<MapObjectData> CollectMapObjects()
    {
      MapObject[] mapObjects = FindObjectsOfType<MapObject>();
      List<MapObjectData> mapObjectData = new List<MapObjectData>(mapObjects.Length);
      mapObjectData.AddRange(mapObjects.Select(mapObject => new MapObjectData(mapObject.transform.position, mapObject.size, mapObject.MinBounds)));

      return mapObjectData;
    }

    private LevelTransferData CollectLevelTransferData()
    {
      LevelTransferMarker marker = FindObjectOfType<LevelTransferMarker>();
      Transform markerTransform = marker.GetComponent<Transform>();
      return new LevelTransferData(markerTransform.position, markerTransform.rotation, marker.transferTo);
    }

    private DoorInitialData CollectDoorStaticData()
    {
      DoorSpawnMarker marker = FindObjectOfType<DoorSpawnMarker>();
      Vector2 position = marker.GetComponent<Transform>().position;
      return new DoorInitialData(marker.rightElementForOpen, position);
    }
  }
}