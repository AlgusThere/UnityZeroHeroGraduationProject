using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float zombieSpeed = 0.5f, detectRange = 10f, attackRange = 1.5f;
    public Transform target;
    public GameObject zombie, damageScreen;
    private Animator animator;
    public AudioSource[] zombieSound;
    public int attack, attackSound;
    private bool isAttack = false, walk = false;

    private float attackCoolDown = 1.5f;
    private float currentCoolDown = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
}
