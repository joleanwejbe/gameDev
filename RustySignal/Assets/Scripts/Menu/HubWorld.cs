using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubWorld : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            AcessSetting("Settings_Game");
        }
    }

    public void AcessSetting(string Settings_Game)
    {
        SceneManager.LoadScene(Settings_Game);
    }
}
