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
    [SerializeField] float jumpForce = 5.4f;
    [SerializeField] float jumpCounter;
    private float coyoteTime;

    [Header("For WallSliding")]
    [SerializeField] float wallSlideSpeed = 1.5f;

    [Header("For WallJumping")]
    [SerializeField] float walljumpforce = 7;
    [SerializeField] Vector2 walljumpAngle = new Vector2 (0.35f, 1f);

    [Header("Other")]
    [SerializeField] int direction = 1;

    private void Start()
    {
        walljumpAngle.Normalize();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        
        base.Update();
        /*if (coyoteTime > 0)
        {
            coyoteTime -= Time.deltaTime;
        }*/
        
        
        XDirectional = transform.position.x;
        
    }

    protected void FixedUpdate()
    {
        Movement(direction);
        Jump();
        WallSlide();
        WallJump();
    }

    void Movement(int direction)
    {
        //for Animation
        if (XDirectional != 0 && IsGround)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //for movement
        if (IsGround)
        {
            jumpCounter = 0;
            isJumping = false;
            rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
        }
        if(IsTouchingWall()) { Flip(); }
    }

    private void Flip()
    {
        direction *= -1;
        transform.Rotate(0, 180, 0);
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
        if (canJump && IsGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            canJump = false;
        }
    }

    void WallSlide()
    {
        if (onWall && VelocityY < 0.01)
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
        }
    }
}