using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] Vector2 direction;
    [SerializeField] KeyCode left = KeyCode.A, right = KeyCode.D;
    [SerializeField] float gravityTimeToZero, turnspeed, minimalGravityEffect;
    [SerializeField] GameObject directionFinder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = directionFinder.transform.position - transform.position;
        if (Input.GetKey(left) && Input.GetKey(right))
        {

        }
        else if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.forward, -turnspeed * Time.deltaTime);
        }
        else if (Input.GetKey(right))
        {
            transform.Rotate(Vector3.forward, turnspeed * Time.deltaTime);
        }
        else
        {

        }
        if (Vector2.Angle(direction, Vector2.down) < minimalGravityEffect * Time.deltaTime)
        {
            if (Vector2.SignedAngle(direction, Vector2.down) < 0)
            {
                transform.Rotate(Vector3.forward, -minimalGravityEffect * Time.deltaTime);
            }
            else if (Vector2.SignedAngle(direction, Vector2.down) > 0)
            {
                transform.Rotate(Vector3.forward, minimalGravityEffect * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(Vector3.forward, Vector2.SignedAngle(direction, Vector2.down) / gravityTimeToZero * Time.deltaTime);
        }
    }
}
