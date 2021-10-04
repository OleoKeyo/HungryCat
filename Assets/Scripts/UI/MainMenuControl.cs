using System;
using System.Collections;
using UnityEngine;


public class MainMenuControl : MonoBehaviour
{
    [Header("utility")] 
    [SerializeField] private GameObject loadManager;
    [Header("panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject authorPanel;
    [SerializeField] private GameObject catPanel;

    [Header("SoundProperties")] 
    [SerializeField] private GameObject soundObject;
    [SerializeField] private AudioClip coreTheme;
    [SerializeField] private AudioClip catTheme;
    private AudioSource _audioSource;

    private SceneLoadManager _sceneLoad;

    private void Start()
    {
        _sceneLoad = loadManager.GetComponent<SceneLoadManager>();
    }
    
    public void OnPlayButton()
    {
        menuPanel.SetActive(false);
        authorPanel.SetActive(false);
        catPanel.SetActive(false);
        
        _sceneLoad.LoadScene(1);
    }

    public void OnAuthorButton()
    {
        menuPanel.SetActive(false);
        authorPanel.SetActive(true);
        catPanel.SetActive(false);
    }
    
    public void OnBackButton()
    {
        menuPanel.SetActive(true);
        authorPanel.SetActive(false);
        catPanel.SetActive(false);
    }
    
    public void OnExitButton()
    {
        Application.Quit();
    }
    
    public void OnGameOver()
    {
        OnPlayButton();
    }

    public void OnCatPanel()
    {
        _sceneLoad.UnloadCurrentScene();
        catPanel.SetActive(true);
        authorPanel.SetActive(false);
        menuPanel.SetActive(false);

        StartCoroutine(CatCoroutine());
    }

    IEnumerator CatCoroutine()
    {
        _audioSource.Stop();
        _audioSource.clip = catTheme;
        
        while(_audioSource.isPlaying) yield return new WaitForEndOfFrame();

        _audioSource.clip = coreTheme;
        OnBackButton();
    }
}
