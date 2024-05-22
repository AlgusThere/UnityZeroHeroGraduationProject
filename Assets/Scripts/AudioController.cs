using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void GameAudios(string AudioName)
    {
        PlayerPrefs.SetString("Audio", AudioName);
        PlayerPrefs.Save();
    }
}
