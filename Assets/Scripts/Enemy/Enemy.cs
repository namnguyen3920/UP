
using UnityEngine;

public abstract class Enemy : Singleton_Mono_Method<Enemy>
{
    protected int moveSpeed;
    protected int direction = -1;

    [SerializeField] protected Transform enemiesPrefabs;
    protected Rigidbody2D rb;
    protected DeadEnemiesPooling enemiesPool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Moving(int direction, float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps") || collision.gameObject.CompareTag("Enemy"))
        {
            PlayerController.d_Instance.Die();
        }
    }

}
