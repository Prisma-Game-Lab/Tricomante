using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;


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
        if (context.performed )
        {
            rb.velocity += Vector2.up * jumpForce;
        }
         
           
    }
//Velocity serve tanto pra vertical quanto pra horizontal
}
