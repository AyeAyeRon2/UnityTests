﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseState : MonoBehaviour
{
    public GameObject pauseUI; // EGO containing the whole pause UI
    public GameObject pauseMenu; // EGO containing the pause UI
    public GameObject optionsMenu; // EGO containing the options UI

    public bool pauseMenuActive;

    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        // hides UI at start of scene
        pauseUI.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        pauseMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // what happens when escape button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // resumes game if pause menu is active
            if (pauseMenuActive)
            {
                Resume();
            }
            // pauses game if else
            else
            {
                GamePaused();
            }
        }
    }
    public void Resume()
    {
        // hides pause UI
        pauseUI.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1.0f; // resumes the game speed
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor
        Cursor.visible = (false); // makes the cursor invisible
        pauseMenuActive = false;
    }
    public void GamePaused()
    {
        // shows pause UI
        pauseUI.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f; // pause game speed
        Cursor.lockState = CursorLockMode.None; // unlocks the cursor
        Cursor.visible = (true); // makes the cursor visible
        pauseMenuActive = true;
    }
    public void LoadMainMenu()
    {
        //SceneManager.LoadScene("SceneName"); // Load the main menu
        Time.timeScale = 1.0f; // resumes time  when leaving game scene to menu
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        Debug.Log(volume);
    }
}
