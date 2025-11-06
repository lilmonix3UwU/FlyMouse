using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    [SerializeField] GameObject looseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject highscoreWinMenu;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            looseMenu.SetActive(true);
            gameObject.GetComponent<CharacterController>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Cheese"))
        {
            gameObject.GetComponent<CameraFollowScript>().enabled = false;
            gameObject.GetComponent<CharacterController>().turnspeed = 0;
            winMenu.SetActive(true);
        }
    }




}
