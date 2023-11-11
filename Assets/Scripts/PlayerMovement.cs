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

    [Header("Velocity")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpHeight = 5f;

    [Space]

    [Header("Counter")]
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private int jumpLefts;


    [Header("Collision Check")]
    [SerializeField] Transform groundCheckCollision;
    public int side = 1;
    private float collisionRadius = 0.2f;
    private Collider2D[] colliderStatus;
    public bool canMove;
    [SerializeField] private bool isGrounded = false;

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
        Running(side);
        if (IsGround())
        {
            PlayerMove();
        }
        if (jumpLefts > 0) {
            if (Input.GetButtonDown("Jump") ) { PlayerJump(); }
        } 
    }
    bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheckCollision.position, collisionRadius, groundLayer);
        
    }

    void Flip()
    {
        transform.localScale = new Vector2((-1) * transform.localScale.x, transform.localScale.y);
    }
    void Running(int direction) 
    {
        
        PlayerMove();
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y); 
    }
    #region Jump n Move

    void PlayerMove()
    {
        anim.SetBool("onGround", isGrounded);
        jumpLefts = maxJumps;
    }
    private void PlayerJump()
    {
        anim.SetBool("onGround", !isGrounded);
        anim.SetTrigger("Jumping");
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        jumpLefts -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            side = -side;
            Flip();
        }
    }
    #endregion
}
