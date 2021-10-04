using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [Header("Utility")] 
    [SerializeField] private GameObject sceneLoad;
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;

    private SceneLoadManager _sceneLoad;

    private void Start()
    {
        _sceneLoad = sceneLoad.GetComponent<SceneLoadManager>();
    }

    public void OnPlayMode()
    {
        mainMenuPanel.SetActive(false);
        _sceneLoad.LoadScene(1);
    }
}
