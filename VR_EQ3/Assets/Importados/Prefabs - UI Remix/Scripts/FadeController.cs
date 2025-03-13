using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public Color effectColor;
    public float fadeDuration;
    private Renderer thisRenderer;
    public bool fadeOnStart = false;
    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    public void FadeIn() {
        Fade(1, 0);
    }
    public void FadeOut()
    {
        Fade(0, 1);
    }
    private void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(fadeEffect(alphaIn, alphaOut));
    }

    public IEnumerator fadeEffect(float alphaIn, float alphaOut) {
        float timer = 0;
        while (timer <= fadeDuration) {
            Color newColor = effectColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, (timer / fadeDuration));
            thisRenderer.material.SetColor("_BaseColor", newColor);
            timer += Time.deltaTime;
            yield return null;
        }
        Color finishColor = effectColor;
        finishColor.a = alphaOut;
        thisRenderer.material.SetColor("_BaseColor", finishColor);
        print(thisRenderer.material.color.a);
    }
}
