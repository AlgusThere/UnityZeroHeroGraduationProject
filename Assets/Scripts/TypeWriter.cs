using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriter : MonoBehaviour
{
    [SerializeField] TMP_Text panelText;
    [SerializeField] string[] texts;
    private int currentIndex = 0;
    [SerializeField] private float delay = 0.1f;
    private Coroutine typingCoroutine;

    private void Start()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        string fulltext = texts[currentIndex];

        for(int i = 0; i <= fulltext.Length; i++)
        {
            string currentText = fulltext.Substring(0,i);
            panelText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    public void ChangeText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        StartTyping();
    }
}
