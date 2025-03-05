using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drive : MonoBehaviour
{
    PlayerInput moveInput;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Animator animator;
    public float Speed = 5f;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    [SerializeField] private TrailRenderer trail;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        playerInput = GetComponent<PlayerInput>();  
        animator = GetComponent<Animator>();
        activeMoveSpeed = Speed;
        trail.emitting = false;
    }

    void Update()
{
    Vector2 movement = new Vector2(playerInput.XAxis, playerInput.YAxis).normalized * activeMoveSpeed * Time.fixedDeltaTime;
    rb.velocity = movement;

    // Mengurangi waktu dash jika sedang melakukan dash
    if (dashCounter > 0)
    {
        dashCounter -= Time.deltaTime;
        if (dashCounter <= 0)
        {
            activeMoveSpeed = Speed; // Kembali ke kecepatan normal setelah dash selesai
            dashCoolCounter = dashCooldown; // Mulai cooldown setelah dash selesai
            trail.emitting = false;
        }
    }

    // Mengurangi cooldown setelah dash
    if (dashCoolCounter > 0)
    {
        dashCoolCounter -= Time.deltaTime;
    }

    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
            movement = new Vector2(playerInput.XAxis, playerInput.YAxis).normalized * activeMoveSpeed * Speed* Time.fixedDeltaTime;
            rb.velocity = movement;
            trail.emitting = true;
        }
    }
}



    public void FixedUpdate()
    {

        
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
