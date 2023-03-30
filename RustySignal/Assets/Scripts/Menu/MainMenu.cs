using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Diagnostics;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadSceneAsync("New_LoadGame");
    }

    public void OnSettingsButtonClick()
    {
        SceneManager.LoadSceneAsync("Settings_MM");
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
        Debug.Log("Button Quit activated");
    }
}
