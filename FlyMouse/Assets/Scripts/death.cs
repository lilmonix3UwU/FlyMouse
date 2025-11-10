using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class death : MonoBehaviour
{
    [SerializeField] GameObject looseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] TMP_Text winMenuTime;
    [SerializeField] GameObject highscoreWinMenu;
    [SerializeField] TMP_Text highscoreWinMenuTime;
    [SerializeField] Leaderboard Leaderboard;
    public float Time;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            looseMenu.SetActive(true);
            gameObject.GetComponent<CharacterController>().enabled = false;
            ScoreTimer.instance.CloseTimer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            Time = ScoreTimer.instance.StopTimer();
            if (Leaderboard.CheckIfHighScore(Time))
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<CameraFollowScript>().enabled = false;
                gameObject.GetComponent<CharacterController>().turnspeed = 0;
                highscoreWinMenu.SetActive(true);
                highscoreWinMenuTime.text = "And you got a HIGHSCORE in\r\nthe top 10 of: " + Time.ToString();
            }
            else
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<CameraFollowScript>().enabled = false;
                gameObject.GetComponent<CharacterController>().turnspeed = 0;
                winMenu.SetActive(true);
                winMenuTime.text = Time.ToString();
            }
        }
    }
}
