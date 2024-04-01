using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GroundEnemies
{
    [SerializeField] Transform enemiesPrefabs;
    [SerializeField] protected float moveSpeed;
    protected Rigidbody2D rb;
    protected DeadEnemiesPooling enemiesPool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Moving(int direction)
    {
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
    }

    protected virtual IEnumerator DeadPropertiesSettings()
    {
        AnimationMN.d_Instance.EnemyAnimUpdate_Dead();
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponentInChildren<GroundEnemies>().enabled = false;
        rb.gravityScale = 2;
        yield return new WaitForSeconds(1f);
        DeadEnemiesPooling.d_Instance.ReturnEnemiesToPool(enemiesPrefabs);
    }
}
