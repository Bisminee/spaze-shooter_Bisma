using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Animator animator;
    public float Speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        playerInput = GetComponent<PlayerInput>();  
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(playerInput.XAxis, playerInput.YAxis).normalized * Speed * Time.fixedDeltaTime;
        rb.velocity = movement;

        // Mengatur parameter animator untuk tilt animation dan blend tree
        animator.SetFloat("xVal", playerInput.XAxis);

        if (playerInput.XAxis > 0)
        {
            animator.SetBool("isHoldingRight", true);
            animator.SetBool("isHoldingLeft", false);
        }
        else if (playerInput.XAxis < 0)
        {
            animator.SetBool("isHoldingRight", false);
            animator.SetBool("isHoldingLeft", true);
        }
        else
        {
            animator.SetBool("isHoldingRight", false);
            animator.SetBool("isHoldingLeft", false);
            animator.Play("Idle");
        }

        
    }
}
