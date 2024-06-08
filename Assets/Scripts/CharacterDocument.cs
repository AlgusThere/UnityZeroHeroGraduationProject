using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDocument : MonoBehaviour
{
	public static float targetDistance;
	public float target;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            target = hit.distance;
            targetDistance = target;
        }
    }
}
