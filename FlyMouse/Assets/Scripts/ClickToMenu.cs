using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToMenu : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] float invisCooldown;
    [SerializeField] float visCooldown;
    [SerializeField] float timer;
    private float cooldown;
    private bool visible = true;
    [SerializeField] float fadeTime;
    private float currentFadeTime = 0;
    [SerializeField] Image fade;
    private bool clicked = false;

    private void Start()
    {
        currentFadeTime = fadeTime;
    }

    void Update()
    {
        if (cooldown <= 0 && visible)
        {
            visible = false;
            cooldown = invisCooldown;
            gameObject.GetComponent<TMP_Text>().enabled = false;
        }
        else if (cooldown <= 0 && !visible)
        {
            visible = true;
            cooldown = visCooldown;
            gameObject.GetComponent<TMP_Text>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || (timer <= 0)) clicked = true;
          
        if (clicked)
        {
            gameObject.GetComponent<TMP_Text>().enabled = false;
            currentFadeTime -= Time.deltaTime;
            float alpha = 1 - Mathf.InverseLerp(0, fadeTime, currentFadeTime);
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
        }
            



        if (currentFadeTime <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        text.text = "or wait " + Mathf.Ceil(timer) + " seconds";
        
        if (!clicked)
        {
            cooldown -= Time.deltaTime;
            timer -= Time.deltaTime;
        }
    }
}
