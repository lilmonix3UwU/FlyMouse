using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    private float seconds;
    private float totalSeconds;
    private int minutes;

    public static ScoreTimer instance;
    [SerializeField] TMP_Text timer;
    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        
        seconds += Time.deltaTime;

        float roundedTimer = Mathf.Round((seconds - 1) * 100) / 100;

        if (seconds > 60)
        {
            seconds -= 60;
            minutes++;
        }

        if (minutes == 0) timer.text = roundedTimer.ToString();
        if (minutes > 0) timer.text = minutes + ":" + roundedTimer.ToString();
        /*
        float roundedTimer = Mathf.Round((seconds - 1) * 100) / 100;

        while (roundedTimer > 60)
        {
            roundedTimer -= 60;
            minutes++;
        }

        if (minutes == 0) timer.text = roundedTimer.ToString();
        if (minutes > 0) timer.text = minutes + ":" + roundedTimer.ToString();
        */
    }
    public float StopTimer()
    {
        return seconds + (minutes * 60) - 1;
    }
    public void CloseTimer()
    {
        timer.gameObject.SetActive(false);
    }
}
