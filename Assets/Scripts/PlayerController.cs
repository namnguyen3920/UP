using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

    [Header("Layers")]
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    public int wallSide;

    [Space]

    [Header("Collision")]

    private float collisionRadius = 0.2f;
    private Vector2 bottomOffset, rightOffset, leftOffset;
    private Collider2D[] colliderStatus;

    [SerializeField] Transform groundCheckCollision;
    [SerializeField] Transform wallCheckCollision;

    private void Awake()
    {
        if (instance == null) { instance = this; }

    }

    void Update()
    {
        wallSide = OnWall() ? -1 : 1;
    }

    public bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheckCollision.position, collisionRadius, groundLayer);
        
    }

    public bool OnWall()
    {
        return Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, wallLayer);
    }

    

    
    //public bool OntWall()
    //{
    //    return Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, wallLayer);
    //}

    //public bool OnLeftWall()
    //{
    //    return Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, leftWallLayer);
    //}
}
