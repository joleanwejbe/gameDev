using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings_Panel;

    void Start()
    {
        if (Settings_Panel != null)
        {
            Settings_Panel.SetActive(false);
        }
    }
    public void OnPlayButtonClick()
    {
        SceneManager.LoadSceneAsync("New_LoadGame");
    }

    public void OnSettingsButtonClick()
    {
        if (Settings_Panel != null)
        {
            Settings_Panel.SetActive(true);
        }
    }

    public void OnHomeButtonClick()
    {
        if (Settings_Panel != null)
        {
            Settings_Panel.SetActive(false);
        }
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
        Debug.Log("Button Quit activated");
    }
}
