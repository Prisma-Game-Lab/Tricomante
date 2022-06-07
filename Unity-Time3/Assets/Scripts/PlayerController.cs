using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    //public Transform groundCheck;
    //public float groundCheckRadius;
    //public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isTouchingGround;
    private float velocityX;
    public GroundCheck groundCheck;
    public static Vector3 playerPosition;

    void Update()
    {
        //isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isTouchingGround = groundCheck.isGrounded;

        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private void Awake()
    {
        transform.position = playerPosition;
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void OnDisable()
    {
        playerPosition = transform.position;
    }

    public void Move(InputAction.CallbackContext context)
    {
        //rb.velocity = context.ReadValue<float>() * Vector2.right * speed; -> antigo
        velocityX = context.ReadValue<float>() * speed;

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isTouchingGround)
        {
            rb.velocity += Vector2.up * jumpForce;
        }
         
           
    }
//Velocity serve tanto pra vertical quanto pra horizontal
}
