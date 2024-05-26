using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
	[SerializeField] GameObject[] Aims;

	private void Start()
	{
		foreach (var aim in Aims)
		{
			aim.GetComponent<Animator>().enabled = false;
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && Bullet.ammo > 0)
		{
			foreach (GameObject aimed in Aims)
			{
				aimed.GetComponent<Animator>().enabled = true;
			}

			StartCoroutine(Waiting());
		}
	}

	IEnumerator Waiting()
	{
		yield return new WaitForSeconds(0.1f);

		foreach (GameObject aimed in Aims)
		{
			aimed.GetComponent<Animator>().enabled = false;
		}
	}
}
