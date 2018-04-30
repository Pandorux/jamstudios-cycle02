using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : SaveableData {

    public Slider soundVol;
    public Slider musicVol;

    void Start()
    {
        soundVol.value = GetSoundVolume();
        musicVol.value = GetMusicVolume();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveSoundVolume()
    {
        SetSoundVolume(soundVol.value);
    }

    public void SaveMusicVolume()
    {
        SetMusicVolume(musicVol.value);
    }

}
