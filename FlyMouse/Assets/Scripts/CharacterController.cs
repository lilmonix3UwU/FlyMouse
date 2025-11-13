using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // ændre momentum til at aftage hurtigere, og gør den exponential.
    [SerializeField] Vector2 direction;
    [SerializeField] KeyCode left = KeyCode.A, right = KeyCode.D;
    public float gravityTimeToTurnZero, turnspeed, minimalGravityTurnEffect, movementSpeed, momentum, maxMomentum, minMomentum;
    [SerializeField] GameObject directionFinder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = directionFinder.transform.position - transform.position;
        InputTaker();
        GravityTurnCalculator();
        Movement();
    }
    void InputTaker()
    {
        if (Input.GetKey(left) && Input.GetKey(right))
        {

        }
        else if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.forward, -turnspeed * Time.deltaTime * Mathf.Clamp(momentum, 1, 3));
        }
        else if (Input.GetKey(right))
        {
            transform.Rotate(Vector3.forward, turnspeed * Time.deltaTime * Mathf.Clamp(momentum, 1, 3));
        }
    }
    void GravityTurnCalculator()
    {
        if (Vector2.Angle(direction, Vector2.down) < minimalGravityTurnEffect * Time.deltaTime)
        {
            if (Vector2.SignedAngle(direction, Vector2.down) < 0)
            {
                transform.Rotate(Vector3.forward, -minimalGravityTurnEffect * Time.deltaTime);
            }
            else if (Vector2.SignedAngle(direction, Vector2.down) > 0)
            {
                transform.Rotate(Vector3.forward, minimalGravityTurnEffect * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(Vector3.forward, Vector2.SignedAngle(direction, Vector2.down) / gravityTimeToTurnZero * Time.deltaTime);
        }
    }
    void Movement()
    {
        transform.position = (Vector2)transform.position + momentum * movementSpeed * Time.deltaTime * direction + Vector2.down * Mathf.Lerp(0.5f, 1f, Mathf.Abs(direction.y)) * Time.deltaTime;
        momentum = Mathf.Clamp(Mathf.Lerp(0f, 2f, Mathf.Abs(direction.y)) * Time.deltaTime * -direction.y * Mathf.Pow(direction.y, 2) + momentum - Mathf.Lerp(0f, 0.5f, Mathf.Abs(direction.x)) * Time.deltaTime, minMomentum, maxMomentum);
    }
}
