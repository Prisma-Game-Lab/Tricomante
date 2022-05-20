using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        rb.velocity = context.ReadValue<float>() * Vector2.right * velocidade;
    }
}
