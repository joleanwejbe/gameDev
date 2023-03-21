using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadSceneAsync("HubWorld", LoadSceneMode.Single);
    }

    public void OnQuitButtonClick()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
