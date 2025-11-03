using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] Vector2 direction;
    [SerializeField] KeyCode left = KeyCode.A, right = KeyCode.D;
    [SerializeField] float gravityTimeToTurnZero, turnspeed, minimalGravityTurnEffect, movementSpeed, momentum, gravityConstant, momentumLossRate, maxMomentum;
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
            transform.Rotate(Vector3.forward, -turnspeed * Time.deltaTime);
        }
        else if (Input.GetKey(right))
        {
            transform.Rotate(Vector3.forward, turnspeed * Time.deltaTime);
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
        
        transform.position = (Vector2)transform.position + momentum * movementSpeed * Time.deltaTime * direction;
        Vector3 previousPosition = transform.position;
        GravityMovement();
        float tempMomentum = Mathf.Clamp(Mathf.Log((transform.position - previousPosition).magnitude / Time.deltaTime, 2), 1, maxMomentum);
        if (tempMomentum > momentum)
        {
            momentum = tempMomentum;
        }
        else
        {
            momentum -= momentumLossRate * Time.deltaTime;
        }
    }
    void GravityMovement()
    {
        transform.position = (Vector2)transform.position + gravityConstant * Mathf.Lerp(0.1f, 1f, Mathf.Abs(direction.y)) * Vector2.down;
    }
}
