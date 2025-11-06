using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToStart : MonoBehaviour
{
    [SerializeField] GameObject otherMenuStuff;
    [SerializeField] float invisCooldown;
    [SerializeField] float visCooldown;
    [SerializeField] float animationTime;
    [SerializeField] float fadeTime;
    private float currentFadeTime = 0;
    [SerializeField] Image fade;
    private float cooldown;
    private bool visible = false;
    private bool clicked = false;
    private bool fadeInDone = false;
    [SerializeField] Animator background;
    void Update()
    {
        if (!fadeInDone)
        {
            currentFadeTime += Time.deltaTime;
            float alpha = 1 - Mathf.InverseLerp(0, fadeTime, currentFadeTime);
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
        }

        if (!fadeInDone && (currentFadeTime >= fadeTime))
        {
            currentFadeTime = fadeTime;
            fadeInDone = true;
        }

        if (fadeInDone)
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

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                gameObject.GetComponent<TMP_Text>().enabled = false;
                otherMenuStuff.SetActive(false);
                clicked = true;
                background.SetBool("NewScene", true);
            }

            if (!clicked) cooldown -= Time.deltaTime;
            else animationTime -= Time.deltaTime;
            if (animationTime <= 0)
            {
                currentFadeTime -= Time.deltaTime;
                float alpha = 1 - Mathf.InverseLerp(0, fadeTime, currentFadeTime);
                fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
            }


            if (currentFadeTime <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }





    }
}
