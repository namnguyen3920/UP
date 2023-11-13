using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [Header("Layer")]
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    [Header("Velocity")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpHeight = 5f;

    [Space]

    [Header("Counter")]
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private int jumpLefts;


    [Header("Collision Check")]
    [SerializeField] Transform groundCheckCollision;
    [SerializeField] Transform wallCheckCollision;
    
    public int side = 1;
    private float collisionRadius = 0.1f;
    private Collider2D[] colliderStatus;
    public bool canMove;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool canWallSlide;
    [SerializeField] private bool isWallSliding;

    private void Awake()
    {
        jumpLefts = maxJumps;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("yVelocity", rb.velocity.y);
        Running(side);
        ChangeSideWhenCollided();
        if (CheckGround())
        {
            jumpLefts = maxJumps;
        }
        if(Input.GetButtonDown("Jump") && jumpLefts > 0)
        {
            PlayerJump();
        }
        SetAnimator();
    }
    bool CheckGround()
    {
       return Physics2D.OverlapCircle(groundCheckCollision.position, collisionRadius, groundLayer);
    }

    bool WallDetected()
    {
        return Physics2D.Raycast(wallCheckCollision.position, Vector2.right, collisionRadius, wallLayer);
    }

    

    
    #region Jump

    private void PlayerJump()
    {
        jumpLefts =- 1;
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        
    }


    #endregion

    #region Sub-funtion
    void SetAnimator()
    {
        if (anim.GetFloat("yVelocity") == 0f)
        {
            anim.SetBool("isGround", true);
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isGround", false);
            anim.SetBool("isJumping", true);
        }
    }
    void Flip()
    {
        transform.localScale = new Vector2((-1) * transform.localScale.x, transform.localScale.y);
    }
    void Running(int direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    void ChangeSideWhenCollided()
    {
        if (WallDetected())
        {
            collisionRadius = -collisionRadius;
            side = -side;
            Flip();
            Running(side);
        }
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheckCollision.position, new Vector3(wallCheckCollision.position.x + collisionRadius,
                                                                 wallCheckCollision.position.y,
                                                                 wallCheckCollision.position.z));

        Gizmos.DrawSphere(groundCheckCollision.position, collisionRadius);
    }
}
