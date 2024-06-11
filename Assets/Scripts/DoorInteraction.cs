using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{

    public float distance = CharacterDocument.targetDistance;
    public GameObject _text, _textKapat, Wall;
    private Animator wallAnimator;

    void Start()
    {
        _textKapat.SetActive(false);
        _text.SetActive(true);
        wallAnimator = Wall.GetComponent<Animator>();
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

    private void InteractionActive()
    {
        if (_text.gameObject.activeInHierarchy)
        {
            _text.SetActive(false);
            _textKapat.SetActive(true);
            wallAnimator.SetTrigger("Open");
        }
        else if(_textKapat.gameObject.activeInHierarchy)
        {
            _text.SetActive(true);
            _textKapat.SetActive(false);
            wallAnimator.SetTrigger("Close");
        }
    }
}
