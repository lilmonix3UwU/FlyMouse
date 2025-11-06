using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneFadein : MonoBehaviour
{
    [SerializeField] float fadeTime;
    float currenFadeTime;
    private void Start()
    {
        currenFadeTime = fadeTime;
    }
    void Update()
    {
        currenFadeTime -= Time.deltaTime;
        float alpha = Mathf.InverseLerp(0, fadeTime, currenFadeTime);
        Color color = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, alpha);
        if (currenFadeTime <= 0) gameObject.GetComponent<MainSceneFadein>().enabled = false;
    }
}
