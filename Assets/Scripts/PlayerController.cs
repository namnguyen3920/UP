using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpHight = 5f;
    [SerializeField] private bool isWall = false;

    [SerializeField] private GameObject right_wall;
    [SerializeField] private GameObject left_wall;
    Rigidbody2D rb;
    private Transform currentDirection;

    private bool isGround = true;
    private float move;
    private Vector3 rotate;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = right_wall.transform;
        rotate = transform.eulerAngles;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
       
    }

    void PlayerMove()
    {
        if (isGround)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CollisionObject")
        {
            isGround = true;
        }
    }
    private void PlayerMoving()
    {
        Vector2 direction = currentDirection.position - transform.position;
        if (currentDirection == right_wall.transform)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }

        if (Vector2.Distance(transform.position, currentDirection.position) < 0.5f && currentDirection == right_wall.transform)
        {
            Flip();
            currentDirection = left_wall.transform;
        }
        if (Vector2.Distance(transform.position, currentDirection.position) < 0.5f && currentDirection == left_wall.transform)
        {
            Flip();
            currentDirection = right_wall.transform;
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
