using System.Linq;
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

        levelData.initialCatPosition = FindObjectOfType<CatSpawnMarker>().GetComponent<Transform>().position;
        levelData.initialDoorPosition = FindObjectOfType<DoorSpawnMarker>().GetComponent<Transform>().position;
        levelData.initialPlayerPosition = FindObjectOfType<PlayerSpawnMarker>().GetComponent<Transform>().position;
      }
      
      EditorUtility.SetDirty(target);
    }
  }
}