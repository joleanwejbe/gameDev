using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseAndVolume : MonoBehaviour
{
    private float musicVolume;
    private AudioSource AudioSource;
    public GameObject ObjectMusic;

    public GameObject panel;
    public Button returnButton;
    public Button exitButton;

    public Text saveText;

    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("demo");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;

        // Add listeners to the return and exit buttons
        returnButton.onClick.AddListener(ReturnToGame);
        exitButton.onClick.AddListener(ExitGame);

        // Hide the panel at the start of the game
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            panel.SetActive(!panel.activeSelf);

            if (panel.activeSelf)
            {
                //pause menu on
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                saveText.text = "\u2661";
            }
            else
            {
                //pause menu off
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                saveText.text = "\u2661";
            }
        }
    }

    void ReturnToGame()
    {
        //Hide panel
        panel.SetActive(false);
        //Unpause
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ExitGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
