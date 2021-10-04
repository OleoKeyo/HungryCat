using System;
using UnityEngine;


public class MainMenuControl : MonoBehaviour
{
    [Header("utility")] 
    [SerializeField] private GameObject loadManager;
    [Header("panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject authorPanel;

    private SceneLoadManager _sceneLoad;

    private void Start()
    {
        _sceneLoad = loadManager.GetComponent<SceneLoadManager>();
    }
    
    public void OnPlayButton()
    {
        menuPanel.SetActive(false);
        authorPanel.SetActive(false);
        
        _sceneLoad.LoadScene(1);
    }

    public void OnAuthorButton()
    {
        menuPanel.SetActive(false);
        authorPanel.SetActive(true);
    }
    
    public void OnBackButton()
    {
        menuPanel.SetActive(true);
        authorPanel.SetActive(false);
    }
    
    public void OnExitButton()
    {
        Application.Quit();
    }
    
    public void OnGameOver()
    {
        OnPlayButton();
    }
}
