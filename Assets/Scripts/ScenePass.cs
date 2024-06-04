using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePass : MonoBehaviour
{

    public Animator anim;

    void Update()
    {
        StartCoroutine(scenePass());
    }

    IEnumerator scenePass()
    {
        anim.SetTrigger("pass");
        yield return new WaitForSeconds(0.20f);
        SceneManager.LoadScene("PartOne");
    }
}
