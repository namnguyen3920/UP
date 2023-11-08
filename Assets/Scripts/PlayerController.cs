using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpHeight = 5f;

    Rigidbody2D rb;
    Animator anim;

    private bool isGround = false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }
    private void FixedUpdate()
    {
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    void PlayerMove()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "CollisionObjects")
        {
            // Đảo ngược hướng di chuyển
            moveSpeed = -moveSpeed;
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
        anim.SetBool("isJumping", !isGround);
    }

    void Flip()
    {
        transform.localScale = new Vector2((-1) * transform.localScale.x, transform.localScale.y);
       
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            anim.SetTrigger("isJumping");
            anim.SetBool("isJumping", !isGround);
            isGround = false;
        }
    }

}
