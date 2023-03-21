using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_LoadGame : MonoBehaviour
{
    public void OnNewGameButtonClick()
    {
        SceneManager.LoadSceneAsync("HubWorld", LoadSceneMode.Single);
    }

    public void OnBackButtonClick()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
