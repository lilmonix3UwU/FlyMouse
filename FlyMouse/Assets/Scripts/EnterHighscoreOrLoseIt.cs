using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterHighscoreOrLoseIt : MonoBehaviour
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
    [SerializeField] GameObject enterHighscore;
    private bool fadeInDone = false;
    [SerializeField] TMP_Text[] nameTextBoxes;
    public string finalName;
    [SerializeField] GameObject selectedObject;
    private int currentTextBox = 0;
    private int currentLetter = 0;
    private string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    [SerializeField] float spacing;
    [SerializeField] Leaderboard Leaderboard;
    [SerializeField] death death;
    private bool lastFade = false;
    private void Start()
    {
        currentFadeTime = fadeTime;
    }

    void Update()
    {
        if (enterHighscore.activeSelf == false)
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

            if (currentFadeTime <= 0)
            {
                if (timer <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

                if (timer > 0)
                {
                    enterHighscore.SetActive(true);
                }
            }

            text.text = "if you don't do it within " + Mathf.Ceil(timer) + " seconds it won't get saved";

            if (!clicked)
            {
                cooldown -= Time.deltaTime;
                timer -= Time.deltaTime;
            }
        }
        else if (!lastFade)
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentLetter++;
                if (currentLetter == 26) currentLetter = 0;
                nameTextBoxes[currentTextBox].text = alphabet[currentLetter];
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                currentLetter = 0;
                currentTextBox++;
                if (currentTextBox < 3) selectedObject.transform.position = nameTextBoxes[currentTextBox].gameObject.transform.position;
                else
                {
                    finalName = nameTextBoxes[0].text + nameTextBoxes[1].text + nameTextBoxes[2].text;
                    Leaderboard.NewScore(finalName, death.Time);

                }
            }

        }
        else if (lastFade)
        {
            currentFadeTime -= Time.deltaTime;
            float alpha = 1 - Mathf.InverseLerp(0, fadeTime, currentFadeTime);
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
            if (currentFadeTime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
