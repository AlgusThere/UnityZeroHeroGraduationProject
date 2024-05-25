using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyHealth = 10;

    public void enemy(int DamageValue)
    {
        enemyHealth -= DamageValue;
    }

    private void Update()
    {
        if (enemyHealth == 0)
        {
            Invoke("enemyDead", 2);
        }
    }

    void enemyDead()
    {
        Destroy(gameObject);
    }
}
