using UnityEngine;

public abstract class Enemy : Singleton_Mono_Method<Enemy>
{
    protected int moveSpeed;
    protected int direction = -1;

    [SerializeField] protected Transform enemiesPrefabs;
    protected Rigidbody2D enemyRB;

    protected abstract void Moving(int direction, float moveSpeed);

    protected virtual void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }
    protected virtual void EnemyDeadAnimation(Animator enemy_aim, string e_dead)
    {
        AnimationMN.d_Instance.SetTriggerAction(enemy_aim, e_dead);
    }
}
