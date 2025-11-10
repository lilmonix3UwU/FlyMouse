using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseHoleSpawning : MonoBehaviour
{
    [SerializeField] GameObject cheeseHole;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cheeseHole.transform.position = new Vector2(collision.transform.position.x, cheeseHole.transform.position.y);
            if (cheeseHole.transform.position.x < (transform.position.x - 3.5f)) cheeseHole.transform.position = new Vector2((transform.position.x - 3.5f), cheeseHole.transform.position.y);
            if (cheeseHole.transform.position.x > (transform.position.x + 3.5f)) cheeseHole.transform.position = new Vector2((transform.position.x + 3.5f), cheeseHole.transform.position.y);
            cheeseHole.SetActive(true);
        }
    }

}
