using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Volume : MonoBehaviour
{
    private float musicVolume;
    private AudioSource AudioSource;
    public GameObject ObjectMusic;

    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("demo");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
    }
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
