using UnityEngine;

public abstract class Enemy : Singleton_Mono_Method<Enemy>
{
    protected int moveSpeed;
    protected int direction = -1;

    [SerializeField] protected Transform enemiesPrefabs;
    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Moving(int direction, float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
    }
    protected virtual void EnemyDeadAnimation(Animator enemy_aim, string e_dead)
    {
        AnimationMN.d_Instance.SetTriggerAction(enemy_aim, e_dead);
    }
}
