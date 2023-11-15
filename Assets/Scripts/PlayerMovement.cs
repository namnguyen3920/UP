using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("For Movement")]
    [SerializeField] float moveSpeed = 3f;
    //[SerializeField] float airMoveSpeed = 10f;
    
    private float XDirectional;
    private bool isMoving;

    [Header("For Jumping")]
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;
    private bool grounded;
    private bool isJumping;
    private bool canJump;

    [Header("For WallSliding")]
    [SerializeField] float wallSlideSpeed;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;
    private bool isTouchingWall;
    private bool isWallSliding;

    [Header("For WallJumping")]
    [SerializeField] float walljumpforce;
    [SerializeField] Vector2 walljumpAngle;

    [Header("Other")]
    [SerializeField] Animator anim;
    [SerializeField] int direction = 1;
    Rigidbody2D rb;



    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        walljumpAngle.Normalize();

    }

    private void Update()
    {
        XDirectional = transform.position.x;
        Inputs();
        CheckWorld();
        AnimationControl();
    }

    private void FixedUpdate()
    {
        Movement(direction);
        Jump();
        WallSlide();
        WallJump();
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (grounded || isWallSliding))
        {
            canJump = true;
        }
    }
    void CheckWorld()
    {
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
        isTouchingWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);
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
            isJumping = false;
            rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
        }
        //else if (!grounded && (!isWallSliding || !isTouchingWall) && XDirectional != 0)
        //{
        //    //rb.AddForce(new Vector2(direction, 0));
        //    //if (Mathf.Abs(rb.velocity.x) > moveSpeed)
        //    //{
        //    //    rb.velocity = new Vector2(XDirectional * moveSpeed, rb.velocity.y);
        //    //}
        //}

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

    void Flip()
    {
        if (isTouchingWall)
        {
            direction *= -1;
            transform.Rotate(0, 180, 0);
        }
    }

    void Jump()
    {
        if (canJump && (grounded || isWallSliding))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            canJump = false;
        }
    }

    void WallSlide()
    {
        
        if (isTouchingWall && !grounded && rb.velocity.y < (0.8 * jumpForce))
        {
            isWallSliding = true;
            Debug.Log("Sliding");
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
        if (isWallSliding && canJump)        {

            rb.AddForce(new Vector2(walljumpforce * walljumpAngle.x, walljumpforce * walljumpAngle.y), ForceMode2D.Impulse);
            Flip();
            canJump = false;
        }
    }

    void AnimationControl()
    {
        anim.SetBool("isGround", isMoving);
        anim.SetBool("isGround", grounded);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isWallSliding", isTouchingWall);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);

    }
}