using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField] AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound.Play();
            if (Bullet.ammo == 0)
            {
                Bullet.ammo += 10;
                this.gameObject.SetActive(false);
            }
            else
            { 
                Bullet.spareAmmo += 10;
                this.gameObject.SetActive(false);
            }
        }
    }
}
