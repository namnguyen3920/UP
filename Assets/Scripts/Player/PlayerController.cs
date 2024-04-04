using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public delegate void UpdateAnimation();

public abstract class PlayerController : Singleton_Mono_Method<PlayerController>
{
    protected Rigidbody2D rb;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;

    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Transform onWallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;


    [Header("Wall checking boolean")]
    protected bool onWall;
    protected bool isTouchingWall;
    protected bool isWallSliding;

    [Header("Ground checking boolean")]
    protected bool grounded;
    protected bool isJumping;
    protected bool canJump;

    [Header("Status checking boolean")]
    protected bool isMoving;
    protected bool isDead;

    public event UpdateAnimation AnimateUpdate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        AnimateUpdate?.Invoke();
        Inputs();
        CheckWorld();
    }

    public bool Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        return isDead = true;
    }

    public void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.Space) && isWallSliding)
        {
            canJump = true;
        }
    }

    public void CheckWorld()
    {
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
        isTouchingWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);
        onWall = Physics2D.OverlapBox(onWallCheckPoint.position, wallCheckSize, 0, wallLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(onWallCheckPoint.position, wallCheckSize);
    }
}
