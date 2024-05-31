using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHeal : MonoBehaviour
{
    public static int OyuncuCan = 10;
    public int icCan;
    public GameObject PlayerHealText;

    private void Start()
    {
        OyuncuCan = 10;
    }

    private void Update()
    {
        icCan = OyuncuCan;
        PlayerHealText.GetComponent<Text>().text = "Saðlýk: " + icCan;

        if(icCan == 0)
        {
            Bullet.ammo = 0;
            Bullet.spareAmmo = 0;
            SceneManager.LoadScene("Menu");
        }
    }
}
