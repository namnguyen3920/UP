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
    public LayerMask rightWallLayer;
    public LayerMask leftWallLayer;

    public int wallSide;

    [Space]

    [Header("Collision")]

    private float collisionRadius = 0.25f;
    private Vector2 bottomOffset, rightOffset, leftOffset;
    private Collider2D[] colliderStatus;

    [SerializeField] Transform groundCheckCollision;
    

    //private void Awake()
    //{
    //    if (instance == null) { instance = this; }

    //}
    //private void Start()
    //{
        
    //}
    //void Update()
    //{
    //    wallSide = OnRightWall() ? -1 : 1;
    //}

    //public bool OnGround()
    //{
    //    colliderStatus = Physics2D.OverlapCircleAll(groundCheckCollision.position, collisionRadius, groundLayer);
    //    if(colliderStatus.Length == 0) { return true; }
    //    else                            return false;
    //}

    //public bool OnWall()
    //{
    //    return Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, rightWallLayer)
    //        || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, leftWallLayer);
    //}
    //public bool OnRightWall()
    //{
    //    return Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, rightWallLayer);
    //}

    //public bool OnLeftWall()
    //{
    //    return Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, leftWallLayer);
    //}
}
