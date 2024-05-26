using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTargetTitle : MonoBehaviour
{
	public float Distance = CharacterDocument.targetDistance;
	public GameObject ShowTitle;

    private void Update()
    {
        Distance = CharacterDocument.targetDistance;
    }

    private void OnMouseOver()
    {
        if (Distance < 8)
        {
            ShowTitle.GetComponent<Text>().text = "Silah� al";
        }
    }

    private void OnMouseExit()
    {
        ShowTitle.GetComponent<Text>().text = "";
    }
}