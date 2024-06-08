using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTargetTitle : MonoBehaviour
{
	public float Distance = CharacterDocument.targetDistance;
	public GameObject ShowTitle;

    private void FixedUpdate()
    {
        Distance = CharacterDocument.targetDistance;
    }

    private void OnMouseOver()
    {
        if (Distance < 10)
        {
            ShowTitle.GetComponent<Text>().text = "Silahý al";
        }
    }

    private void OnMouseExit()
    {
        ShowTitle.GetComponent<Text>().text = "";
    }
}
