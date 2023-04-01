using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private AudioSource AudioSource;
    public GameObject ObjectMusic;

    public Slider volumeSlider;
    private float musicVolume = 1f;

    void Start()
    {
        //get music playing from Main Menu
        ObjectMusic = GameObject.FindWithTag("MM_Music");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        //volume and saving it
        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;

        //reppearing cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

    public void resetMusic()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadSceneAsync("HubWorld", LoadSceneMode.Single);
    }

    public void ToMainMenuButtonClick()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
