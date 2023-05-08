using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silo_music : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2f;

    private Coroutine fadeCoroutine;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        float startVolume = 0f;
        float endVolume = musicVolume;
        float currentTime = 0f;

        audioSource.volume = startVolume;
        audioSource.Play();

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float volume = Mathf.Lerp(startVolume, endVolume, currentTime / fadeDuration);
            audioSource.volume = volume;
            yield return null;
        }

        audioSource.volume = endVolume;
    }

    private IEnumerator FadeOut()
    {
        float startVolume = audioSource.volume;
        float endVolume = 0f;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float volume = Mathf.Lerp(startVolume, endVolume, currentTime / fadeDuration);
            audioSource.volume = volume;
            yield return null;
        }

        audioSource.volume = endVolume;
        audioSource.Stop();
    }
}