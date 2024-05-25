using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTrigger : MonoBehaviour
{
    [SerializeField] int damage = 5;
    [SerializeField] float targetDistance, currentDistance = 15f;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit Shot;

            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                targetDistance = Shot.distance;

                if(targetDistance <= currentDistance)
                {
                    Shot.transform.SendMessage("enemy", damage);
                }
            }
        }
    }
}
