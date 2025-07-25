using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TakeDamePanel : MonoBehaviour
{
    public static TakeDamePanel instance;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float blinkDuration = 0.2f;
    [SerializeField] private float totalBlinkTime = 2f;

    private Coroutine blinkCoroutine;
    private bool isBlinking = false;

    private void Awake()
    {
        instance = this;
    }

    void OnValidate()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        canvasGroup.alpha = 0;
    }
    [Button]
    public void ShowWarning()
    {
        if (isBlinking) return;

        canvasGroup.alpha = 1;
        isBlinking = true;

        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);

        blinkCoroutine = StartCoroutine(BlinkEffect());
    }

  
    public IEnumerator BlinkEffect()
    {
        float elapsed = 0f;
        bool fadingOut = true;
        canvasGroup.alpha = 1;

        while (elapsed < totalBlinkTime)
        {
            float timer = 0f;
            float startAlpha = canvasGroup.alpha;
            float endAlpha = fadingOut ? 0f : 1f;

            while (timer < blinkDuration)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, timer / blinkDuration);
                yield return null;
            }

            canvasGroup.alpha = endAlpha;
            fadingOut = !fadingOut;
            elapsed += blinkDuration;
        }

        canvasGroup.alpha = 1;
        isBlinking = false;
        blinkCoroutine = null;
        canvasGroup.alpha = 0;
    }
}