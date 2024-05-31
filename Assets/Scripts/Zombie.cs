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

    [SerializeField] int enemyHealth = 10;

    private float attackCoolDown = 1.5f;
    private float currentCoolDown = 0;

    public void enemy(int DamageValue)
    {
        enemyHealth -= DamageValue;
    }

    private void Start()
    {
        animator = zombie.GetComponent<Animator>();

        InvokeRepeating("RandomMovement", 0f, 2f);
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= attackRange)
            {
                Attack();
            }
            else if (distanceToTarget <= detectRange)
            {
                MoveTowardsTarget();
                walk = true;
            }
            else
            {
                walk = false;
                animator.SetBool("walk", true);
                animator.SetBool("isAttack", false);
                RandomMovement();
            }
        }
        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
        }
        else
        {
            isAttack = false;
        }

        void RandomMovement()
        {
            if (!walk)
            {
                float randomAngle = Random.Range(0, 360f);
                transform.Rotate(0f, randomAngle, 0f);
            }
        }
        void MoveTowardsTarget()
        {
            transform.LookAt(target);
            transform.position += transform.forward * zombieSpeed * Time.deltaTime;
            animator.SetBool("walk", true);
            animator.SetBool("isAttack", false);
        }

        if (enemyHealth == 0)
        {
            zombie.GetComponent<Animator>().SetBool("death", true);
            zombie.GetComponent<Animator>().SetBool("walk", false);
            zombie.GetComponent<Animator>().SetBool("isAttack", false);
            Invoke("enemyDead", 2);
        }
    }

    void enemyDead()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        animator.SetBool("walk", false);
        animator.SetBool("isAttack", true);
        if (!isAttack && PlayerHeal.OyuncuCan > 0)
        {
            isAttack = true;
            PlayerHeal.OyuncuCan -= 1;
            currentCoolDown = attackCoolDown;
            if(PlayerHeal.OyuncuCan > 0 )
            {
                int randomSoundIndex = Random.Range(0, zombieSound.Length);
                zombieSound[randomSoundIndex].Play();

                StartCoroutine(ActiveAndDeactiveHealScreen());
            }
        }
    }

    IEnumerator ActiveAndDeactiveHealScreen()
    {
        damageScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        damageScreen.SetActive(false);
    }
}
