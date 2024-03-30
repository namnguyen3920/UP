using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemies : EnemyCtrl
{
    [Header("Checking Collision")]
    //[SerializeField] protected float moveSpeed;
    [SerializeField] private Transform checkPointCollision;
    [SerializeField] private Transform checkPointGround;
    [SerializeField] Vector2 collisionCheckSize;
    [SerializeField] LayerMask collisionLayerMask;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] float groundCheckRadius;
    int direction = -1;

    private void Awake()
    {
        
    } 
    
    private void Update()
    {
        CollisionCheck();
        Moving(direction);
        //PatrolMoment();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            StartCoroutine(DeadAnimation());
        }
    }

    bool IsCollision()
    {
        return Physics2D.OverlapBox(checkPointCollision.position, collisionCheckSize, 0, collisionLayerMask);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(checkPointGround.position, groundCheckRadius, groundLayerMask);
    }

    void CollisionCheck()
    {
        if (IsCollision() || !IsGrounded())
        {
            direction *= -1;
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(checkPointCollision.position, collisionCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(checkPointGround.position, groundCheckRadius);
    }
}
