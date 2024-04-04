using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : GroundEnemies
{
    [SerializeField] Animator chicken_anim;
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
            AnimationMN.d_Instance.SetTriggerDead(chicken_anim, "Dead");
            StartCoroutine(DeadPropertiesSettings());
        }
    }

}
