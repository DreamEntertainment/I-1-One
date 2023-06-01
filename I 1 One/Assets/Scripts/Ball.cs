using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D ballRB;
    [SerializeField] float ballInitialSpeed = 5f;
    float ballSpeed;
    float maxBounceAngle;
    float desiredSpeed = 500f;
    bool hasContacted;

    //remove if angle bounce doesn't work
    PlayerMovements playerMovements;
    float maxAngle = 70f;
    float minAngle = 1f;

    void Start()
    {
        ballSpeed = ballInitialSpeed;
        ballRB = GetComponent<Rigidbody2D>();
        playerMovements = FindObjectOfType<PlayerMovements>();

        Launch();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        float contactPointX = contact.point.x;
        Transform paddleTransform = collision.gameObject.transform;
        float paddleWidth = paddleTransform.localScale.x; // Assuming paddle's width is based on scale

        float contactPoint = contactPointX - paddleTransform.position.x;
        float normalizedContactPoint = contactPoint / (paddleWidth / 2);
        float minAngle = 0;  // Minimum bounce angle in degrees
        float maxAngle = 70; // Maximum bounce angle in degrees
        float bounceAngle = minAngle + (maxAngle - minAngle) * normalizedContactPoint;

        if (contactPoint < 0)
        {
            bounceAngle = -bounceAngle;
        }

        // Convert bounce angle to radians
        float bounceAngleRadians = Mathf.Deg2Rad * bounceAngle;

        // Calculate new velocity based on the bounce angle
        Rigidbody2D ballRigidbody = GetComponent<Rigidbody2D>(); // Assuming the ball has a Rigidbody2D component
        float ballSpeed = ballRigidbody.velocity.magnitude;
        Vector2 newVelocity = new Vector2(Mathf.Cos(bounceAngleRadians), Mathf.Sin(bounceAngleRadians)) * ballSpeed;

        // Apply the new velocity to the ball
        ballRigidbody.velocity = newVelocity;
























        /* ContactPoint2D contact = collision.GetContact(0);
         float contactPointY = contact.point.y;
         Transform playerTransform = collision.gameObject.transform;
         float playerWidth = playerTransform.localScale.y;

         SpriteRenderer playerSprite = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
         float paddleHeight = playerSprite.bounds.size.y;

         float contactPoint2 = contactPointY - playerTransform.position.y;
         float normalizedContactPoint = contactPointY / (paddleHeight / 2);
         float bounceAngle = minAngle + (maxAngle - minAngle) * normalizedContactPoint;

         if (contactPoint2 < 0)
         {
             bounceAngle = -bounceAngle;
         }

         float bounceAngleRadians = Mathf.Deg2Rad * bounceAngle;

         Vector2 bounceDirection = new Vector2(Mathf.Cos(bounceAngle), Mathf.Sin(bounceAngle));

         ballRB.velocity = ballRB.velocity.magnitude * bounceDirection;
 */


        /*  if (!hasContacted)
          {
              float centerOffset = 0.5f;
              SpriteRenderer playerSprite = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
              float actualPaddleHeight = playerSprite.bounds.size.y;
              ContactPoint2D contactPoint = collision.GetContact(0);
              Vector2 playerHeight = collision.gameObject.transform.position;
              Vector2 relativePos = contactPoint.point - playerHeight;
              float offsetFactor = Mathf.Abs(relativePos.x / (actualPaddleHeight * 0.5f));

              float desiredAngle = Mathf.Lerp(maxAngle, -maxAngle, relativePos.y / actualPaddleHeight);
              desiredAngle *= (1 - centerOffset * offsetFactor);

              Vector2 direction = new Vector2(Mathf.Cos(desiredAngle), Mathf.Sin(desiredAngle));
              ballRB.velocity += direction * Time.deltaTime;
              hasContacted = true;
          }*/
    }










   
    void Launch()
    {
        if (Random.value < 0.5f)
        {
            ballRB.AddForce(transform.right * ballSpeed * Time.deltaTime);
        }
        else
        {
            ballRB.AddForce(-transform.right * ballSpeed * Time.deltaTime);
        }
    }
}




//invoke ball launch