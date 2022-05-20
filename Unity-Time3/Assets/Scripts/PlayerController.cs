using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isTouchingGround;

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    public void Move(InputAction.CallbackContext context)
    {
        //rb.velocity = context.ReadValue<float>() * Vector2.right * speed; -> antigo
        rb.velocity = new Vector2(context.ReadValue<float>() * speed, rb.velocity.y);

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
