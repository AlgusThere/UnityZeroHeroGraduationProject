using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private AudioClip ShotSound;
    private AudioSource ShotSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        ShotSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Bullet.ammo > 0 )
        {
            ShotSource.PlayOneShot(ShotSound);
            //AudioSource gunSound = GetComponent<AudioSource>();
            //gunSound.Play();
            _animator.SetBool("isTrigger", true);
        }
        else
        {
            _animator.SetBool("isTrigger", false);
        }
    }
}
