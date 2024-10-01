using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlink : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] float changeValue;
    [SerializeField] float waitTime;


    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        StartCoroutine(nameof(FadeOut));
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        StartCoroutine(nameof(FadeIn));
    }

    void Update()
    {
        
    }
}
