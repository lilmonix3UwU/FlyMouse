using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    private float seconds;
    public static ScoreTimer instance;
    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        seconds += Time.deltaTime;


    }
    public float StopTimer()
    {
        return seconds -1;
    }
}
