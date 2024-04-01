using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Enemy
{
    private void Update()
    {
        CollisionCheck();
        Moving(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerFeet")) 
        {
            StartCoroutine(DeadPropertiesSettings());
        }
    }

}
