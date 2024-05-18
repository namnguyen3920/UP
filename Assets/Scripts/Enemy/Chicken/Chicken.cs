
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
            chicken_speed = 0;
            StartCoroutine(DeadPropertiesSettings());
        }
    }

}
