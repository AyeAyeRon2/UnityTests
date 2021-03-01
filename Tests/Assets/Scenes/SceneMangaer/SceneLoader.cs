using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header ("Main Menu Scene")]
    [SerializeField] private string mainMenuSceneName;
    [Header("Game Scene")]
    [SerializeField] private string gameSceneName;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
