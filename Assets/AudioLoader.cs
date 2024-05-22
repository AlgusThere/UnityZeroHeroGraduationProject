using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoader : MonoBehaviour
{
    [SerializeField] private AudioSource ses;

    private void Start()
    {
        PlayerPrefs.GetString("Audio", "");
    }
}
