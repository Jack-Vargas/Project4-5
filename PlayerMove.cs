using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float WalkForce = 8;
    public float JumpForce = 7;
    public bool IsFacingRight = true;
    public Transform GroundCheck;
    private float horizontal = 0;
    public LayerMask GroundLayer;
    public float YMultiplier = 1f;
    public Dash script;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (script.isDashing)
        {
            return;//keeps this script from interupting the dash action moving the player
        }
        float movehor = Input.GetAxis("Horizontal") * WalkForce;
        rb2D.velocity = new Vector3(movehor, rb2D.velocity.y);

        if (IsGrounded())
        {
            animator.SetFloat("xVelocity", Math.Abs(horizontal));//math Abs sets a avlue to be absolute "always positive"
        }
        
    }

    void Update()
    {
        if (script.isDashing)
        {
            return;//keeps this script from interupting the dash action moving the player
        }
        
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        if ( Input.GetKeyDown(KeyCode.W) && IsGrounded() && script.isDashing == false)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, JumpForce);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
        //spent so much time on the above code and here is what i learned;
        //1. dont put a ; at the end of the GetButtonUp if statement
        //2. in the aformentioned statement i used rb2d.velocity.y instead of JumpForce
        //once all of this was cleared up the code worked fine

        if (IsGrounded())
        {
            script.dashAv = true;
        }
    }

    private void Flip()
    {
        if (IsFacingRight && horizontal < 0f || !IsFacingRight && horizontal > 0f)
        {
            IsFacingRight = !IsFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.1f, GroundLayer);
    }
}
