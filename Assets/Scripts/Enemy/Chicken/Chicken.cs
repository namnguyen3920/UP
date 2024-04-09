using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : GroundEnemies
{
    [SerializeField] float chicken_speed;
    
    protected override void Update()
    {
        base.Update();
        Moving(direction, chicken_speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerFeet")) 
        {
            StartCoroutine(DeadPropertiesSettings());
        }
    }

}
