using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    [SerializeField] GameObject looseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject highscoreWinMenu;
    [SerializeField] Leaderboard Leaderboard;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            looseMenu.SetActive(true);
            gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            if (!Leaderboard.CheckIfHighScore(ScoreTimer.Instance.StopTime))
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<CameraFollowScript>().enabled = false;
                gameObject.GetComponent<CharacterController>().turnspeed = 0;
                winMenu.SetActive(true);
            }
            else
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<CameraFollowScript>().enabled = false;
                gameObject.GetComponent<CharacterController>().turnspeed = 0;
                highscoreWinMenu.SetActive(true);
            }
        }
    }




}
