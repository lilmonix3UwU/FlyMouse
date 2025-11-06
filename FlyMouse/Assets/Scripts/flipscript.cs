using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipscript : MonoBehaviour
{
    [SerializeField] GameObject directionFinder;
    void Update()
    {
        if (directionFinder.transform.position.x > transform.position.x) gameObject.GetComponent<SpriteRenderer>().flipY = false;
        if (directionFinder.transform.position.x < transform.position.x) gameObject.GetComponent<SpriteRenderer>().flipY = true;
    }
}
