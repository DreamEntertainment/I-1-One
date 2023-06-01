using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] float playerSpeed = 500f;
    public bool isPlayerTwo;
    Rigidbody2D playerRB;
    [SerializeField] float _topClamp = 3.8f;
    [SerializeField] float _bottomClamp = -3.8f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        ClampMovement();
    }

    void Movement()
    {
        if (isPlayerTwo && gameObject.CompareTag("Player_2"))
        {
                float v = Input.GetAxisRaw("Vertical2");
                playerRB.velocity = new Vector2(playerRB.velocity.x, v * playerSpeed) * Time.deltaTime;
        }
    }
    
    void ClampMovement()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.y = Mathf.Clamp(clampedPos.y, _bottomClamp, _topClamp);
        transform.position = clampedPos;
    }
}
