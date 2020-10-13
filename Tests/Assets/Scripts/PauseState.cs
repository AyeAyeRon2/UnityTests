using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public bool pauseMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        pauseMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuActive)
            {
                Resume();
            }

            else
            {
                GamePaused();

            }
        }
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1.0f;
        pauseMenuActive = false;
    }
    public void GamePaused()
    {
        pauseUI.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        pauseMenuActive = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
