using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
	[SerializeField] AudioSource sound;
	public GameObject trigger, bullet;
	public int ammo, spareAmmo, spareScreen;
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		ammo = Bullet.ammo;
		spareAmmo = Bullet.spareAmmo;

		if (spareAmmo == 0)
		{
			spareScreen = 0;
		}
		else
		{
			spareScreen = 10 - ammo;
		}

		if (ammo <= 0)
		{
			trigger.GetComponent<PullTrigger>().enabled = false;
			bullet.GetComponent<Bullet>().enabled = false;
			animator.SetBool("isTrigger", false);
		}
		else
		{
			trigger.GetComponent<PullTrigger>().enabled = true;
			bullet.GetComponent<Bullet>().enabled = true;

		}

		if (Input.GetButtonDown("Reload"))
		{
			if (spareScreen >= 1)
			{
				animator.SetBool("Reload", true);
				if (spareAmmo <= spareScreen)
				{
					Bullet.ammo += spareAmmo;
					Bullet.spareAmmo -= spareAmmo;
					ActionReload();
				}
				else
				{
					Bullet.ammo += spareScreen;
					Bullet.spareAmmo -= spareScreen;
					ActionReload();
				}
			}

			StartCoroutine(EnableScript());
		}
	}

	IEnumerator EnableScript()
	{
		yield return new WaitForSeconds(0.167f);
		trigger.SetActive(true);
		animator.SetBool("Reload", false);
	}

	void ActionReload()
	{
		trigger.SetActive(false);
		sound.Play();
	}
}
