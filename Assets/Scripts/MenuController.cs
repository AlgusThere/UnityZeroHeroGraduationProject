using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Volum Settings")]
    [SerializeField] private TMP_Text volumeValueText = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Level To Load")]
    public string loadScene;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        SetVolume(defaultVolume);
        Cursor.lockState = CursorLockMode.None;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeValueText.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }

    public void ResetVolume(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeValueText.text = defaultVolume.ToString("0.0");
            volumeSlider.value = defaultVolume;
            VolumeApply();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(loadScene);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
