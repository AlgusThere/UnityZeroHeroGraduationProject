using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _animator != false)
        {
            AudioSource gunSound = GetComponent<AudioSource>();
            gunSound.Play();
            _animator.SetBool("isTrigger", true);
        }
        else
        {
            _animator.SetBool("isTrigger", false);
        }
    }
}