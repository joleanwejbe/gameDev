using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadSystem : MonoBehaviour
{
    private string lastScene;

    public Button button;

    public Text saveText;

    void Start()
    {
        lastScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;
    }

    public void Save()
    {
        PlayerPrefs.SetString("lastScene", lastScene);
        PlayerPrefs.Save();
        saveText.text = "Game Saved!";
    }

    public void Load()
    {
        string lastSceneName = PlayerPrefs.GetString("lastScene");

        if (string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene("HubWorld");
        }
        else
        {
            SceneManager.LoadScene(lastSceneName);
        }
    }
}