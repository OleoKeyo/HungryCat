﻿using System.Linq;
using AlchemyCat.Infrastructure.Services.StaticData;
using AlchemyCat.SpawnMarkers;
using AlchemyCat.StaticData;
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
      }
      
      EditorUtility.SetDirty(target);
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