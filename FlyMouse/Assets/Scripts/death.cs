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
    private int minutes = 0;
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
            ScoreTimer.instance.CloseTimer();
            if (Leaderboard.CheckIfHighScore(Time))
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<CameraFollowScript>().enabled = false;
                gameObject.GetComponent<CharacterController>().turnspeed = 0;
                highscoreWinMenu.SetActive(true);
                float roundedTimer = Mathf.Round((Time - 1) * 100) / 100;

                while (roundedTimer > 60)
                {
                    roundedTimer -= 60;
                    minutes++;
                }

                if (minutes == 0) highscoreWinMenuTime.text = "And you got a HIGHSCORE in\r\nthe top 10 of: " + roundedTimer.ToString();
                if (minutes > 0) highscoreWinMenuTime.text = "And you got a HIGHSCORE in\r\nthe top 10 of: " + minutes + ":" + roundedTimer.ToString();
            }
            else
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<CameraFollowScript>().enabled = false;
                gameObject.GetComponent<CharacterController>().turnspeed = 0;
                winMenu.SetActive(true);
                float roundedTimer = Mathf.Round((Time - 1) * 100) / 100;

                while (roundedTimer > 60)
                {
                    roundedTimer -= 60;
                    minutes++;
                }

                if (minutes == 0) winMenuTime.text = "but you didn't get a highscore.\r\nyou got a time of: " + roundedTimer.ToString();
                if (minutes > 0) winMenuTime.text = "but you didn't get a highscore.\r\nyou got a time of: " + minutes + ":" + roundedTimer.ToString();
            }
        }
    }
}
