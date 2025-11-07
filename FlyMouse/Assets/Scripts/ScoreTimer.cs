using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    private float seconds;
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
        timer.text = roundedTimer.ToString();
       // if (timer)

    }
    public float StopTimer()
    {
        return seconds - 1;
    }
    public void CloseTimer()
    {
        timer.gameObject.SetActive(false);
    }
}
