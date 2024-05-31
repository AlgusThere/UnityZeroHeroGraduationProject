using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicTime;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        musicTime = PlayerPrefs.GetFloat("MusicTime", 0f);
    }

    private void Start()
    {
        PlayMusic();
    }

    private void Update()
    {
        musicTime = audioSource.time;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicTime", musicTime);
        PlayerPrefs.Save();
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.time = musicTime;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
