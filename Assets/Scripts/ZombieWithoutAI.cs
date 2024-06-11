using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class ZombieWithoutAI : MonoBehaviour
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

    //[Header("AI")]
    //public NavMeshAgent agent;
    //public float range;
    //public Transform centrePoint;

    public void enemy(int DamageValue)
    {
        enemyHealth -= DamageValue;
    }

    private void Start()
    {
        animator = zombie.GetComponent<Animator>();

        InvokeRepeating("RandomMovement", 0f, 2f);

        //agent = GetComponent<NavMeshAgent>();
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
                //agent.enabled = false;
                MoveTowardsTarget();
                walk = true;
            }
            else
            {
                //agent.enabled = true;
                walk = false;
                animator.SetBool("walk", false);
                animator.SetBool("isAttack", false);
                //randomMovementTry();
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
            if (PlayerHeal.OyuncuCan > 0)
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

    //void randomMovementTry()
    //{

    //    if (agent.remainingDistance <= agent.stoppingDistance)
    //    {
    //        Vector3 point;
    //        if (RandomPoint(centrePoint.position, range, out point))
    //        {
    //            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
    //            agent.SetDestination(point);
    //        }
    //    }
    //    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    //    {

    //        Vector3 randomPoint = center + Random.insideUnitSphere * range;
    //        NavMeshHit hit;
    //        if (NavMesh.SamplePosition(randomPoint, out hit, 1f, NavMesh.AllAreas))
    //        {
    //            result = hit.position;
    //            return true;
    //        }

    //        result = Vector3.zero;
    //        return false;
    //    }
    //}
}
