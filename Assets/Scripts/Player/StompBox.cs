using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    PlayerMovement movement;
    [SerializeField] float bounce;
    [SerializeField] Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StompSpot"))
        {
            Debug.Log("Hit!!!!");
            rb.velocity = new Vector2(rb.velocity.x, bounce);            
        }
    }
}
