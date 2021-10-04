using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject authorPanel;

    public void OnAuthorButton()
    {
        menuPanel.SetActive(false);
        authorPanel.SetActive(true);
    }
    
    public void OnExitButton()
    {
        Application.Quit();
    }
}
