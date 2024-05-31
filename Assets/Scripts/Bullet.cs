using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
	public static int ammo, spareAmmo;
	public int internalAmmo, spareInternalAmmo = 0;

	[SerializeField] GameObject Ammo, SpareAmmo;

    private void Update()
    {
        internalAmmo = ammo;
        Ammo.GetComponent<Text>().text = " " + internalAmmo;
        spareInternalAmmo = spareAmmo;
        SpareAmmo.GetComponent<Text>().text = " " + spareInternalAmmo;
        if(ammo == 0)
        {
            Ammo.GetComponent<Text>().text = "0";
        }
    }
}
