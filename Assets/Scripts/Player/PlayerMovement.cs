using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : PlayerController
{
    [Header("For Movement")]
    [SerializeField] float moveSpeed = 3f;
    private float XDirectional;
 
    [Header("For Jumping")]
    [SerializeField] float jumpForce = 5.5f;
    [SerializeField] float jumpCounter;
    private float coyoteTime;

    [Header("For WallSliding")]
    [SerializeField] float wallSlideSpeed = 1.5f;

    [Header("For WallJumping")]
    [SerializeField] float walljumpforce = 6;
    [SerializeField] Vector2 walljumpAngle = new Vector2 (0.4f, 1.1f);


    [Header("Other")]
    [SerializeField] int direction = 1;

    private void Start()
    {
        walljumpAngle.Normalize();
    }
    protected override void Update()
    {
        base.Update();
        if (coyoteTime > 0)
        {
            coyoteTime -= Time.deltaTime;
        }

        XDirectional = transform.position.x;
    }

    private void FixedUpdate()
    {
        Movement(direction);
        Jump();
        WallSlide();
        WallJump();
    }

    void Movement(int direction)
    {
        //for Animation
        if (XDirectional != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //for movement
        if (grounded)
        {
            jumpCounter = 0;
            isJumping = false;
            rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
        }

        //for fliping
        if (XDirectional < 0)
        {
            Flip();
        }
        else if (XDirectional > 0)
        {
            Flip();
            
        }
    }

    public void Flip()
    {
        if (isTouchingWall) 
        {
            direction *= -1;
            transform.Rotate(0, 180, 0);
        }
            
    }

    void JumpReset()
    {
        if(jumpCounter < 2) 
        { 
            jumpCounter += 1;
            canJump = true;
        }
        else canJump = false;
    }

    void Jump()
    {
        if (canJump && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            canJump = false;
        }
    }

    void WallSlide()
    {
        if (onWall && !grounded && rb.velocity.y < 0)
         {
             isWallSliding = true;
             rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }
        else
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            WallJump();
        }
    }
    void WallJump()
    {
        if (canJump && onWall)
        {
            rb.AddForce(new Vector2(walljumpforce * walljumpAngle.x * direction, walljumpforce * walljumpAngle.y), ForceMode2D.Impulse);
            canJump = false;
            Flip();
        }
    }

    
}