using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    public bool isPlayerOne;
    public bool isPlayerTwo;
    Rigidbody2D playerRB;
    [SerializeField] float _topClamp = 3.8f;
    [SerializeField] float _bottomClamp = -3.8f;

    /*public SpriteRenderer playerSpriteRender; //delete if bounce angle doesn't work

    void Start()
    {
        playerSpriteRender = GetComponent<SpriteRenderer>();    
    }*/

    void Update()
    {
        PlayerOneMovement();
        PlayerTwoMovement();
        ClampMovement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePos = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePos.y - contactPoint.y;
            float width = collision.otherCollider.bounds.size.y / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
        }
    }

    void PlayerOneMovement()
    {
        if (Input.GetKey(KeyCode.W) && isPlayerOne)
        {
            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && isPlayerOne)
        {
            transform.position += Vector3.down * playerSpeed * Time.deltaTime;
        }
    }

    void PlayerTwoMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isPlayerTwo)
        {
            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && isPlayerTwo)
        {
            transform.position += Vector3.down * playerSpeed * Time.deltaTime;
        }
    }

    void ClampMovement()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.y = Mathf.Clamp(clampedPos.y, _bottomClamp, _topClamp);
        transform.position = clampedPos;
    }
}
