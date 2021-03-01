using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider, musicSlider, sfxSlider;

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MasterPref = "MasterPref";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SFXPref = "SFXPref";

    private int firstPlayInt;
    private float masterFloat, musicFloat, sfxFloat;

    public void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        // if first time playing
        if (firstPlayInt == 0)
        {
            masterFloat = 1f;
            musicFloat = 1f;
            sfxFloat = 1f;
            masterSlider.value = masterFloat;
            musicSlider.value = musicFloat;
            sfxSlider.value = sfxFloat;

            PlayerPrefs.SetFloat(MasterPref, masterFloat); // sets the float to the Pref
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SFXPref, sfxFloat);
            PlayerPrefs.SetInt(FirstPlay, -1); // changes int to determine the game has been played before
        }
        // if not the first time playing
        else
        {
            masterFloat = PlayerPrefs.GetFloat(MasterPref); // sets the float from the saved value
            masterSlider.value = masterFloat; // sets the slider to the float
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            sfxFloat = PlayerPrefs.GetFloat(SFXPref);
            sfxSlider.value = sfxFloat;
        }
        
    }

    public void Update()
    {
        // updates float to slider position
        masterFloat = masterSlider.value;
        musicFloat = musicSlider.value;
        sfxFloat = sfxSlider.value;
        // console debugging purpose
        Debug.Log("Master Volume = " + masterFloat);
        Debug.Log("Music Volume = " + musicFloat);
        Debug.Log("SFX Volume = " + sfxFloat);
    }
    // method to save sound
    // used when changing scenes or exiting menu
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(MasterPref, masterSlider.value); 
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SFXPref, sfxSlider.value);
    }
    // calls the method to save sound settings when the program is out of focus
    public void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        // constantly updates the sound
        audioMixer.SetFloat("MasterVol", Mathf.Log10(masterFloat) * 20);
        audioMixer.SetFloat("MusicVol", Mathf.Log10(musicFloat) * 20);
        audioMixer.SetFloat("SFXVol", Mathf.Log10(sfxFloat) * 20);
    }
    // load scenes for testing purposes
    public void ToGame()
    {
        SceneManager.LoadScene("AudioGame");
    }
    public void ToMain()
    {
        SceneManager.LoadScene("AudioMenu");
    }
}
