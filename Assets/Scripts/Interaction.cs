using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float distance = CharacterDocument.targetDistance;
    public GameObject _text, mainGun, spareGun, _ammo;
    public AudioSource interactionSound;

    private void Start()
    {
        _text.SetActive(false);
        mainGun.SetActive(false);
        _ammo.SetActive(false);
    }

    private void FixedUpdate()
    {
        distance = CharacterDocument.targetDistance;

        if (Input.GetButtonDown("Interaction"))
        {
            if (distance <= 3)
            {
                InteractionActive();
            }
        }
    }

    void InteractionActive()
    {
        interactionSound.Play();
        transform.position = new Vector3(0, -50, 0);
        spareGun.SetActive(true);
        mainGun.SetActive(true);
        _ammo.SetActive(true);
        _text.SetActive(true);
    }
}
