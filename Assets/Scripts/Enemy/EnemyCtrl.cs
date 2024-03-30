using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCtrl : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    protected Rigidbody rb;
    DeadEnemiesPooling enemiesPool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Moving(int direction)
    {
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
    }

    protected IEnumerator DeadAnimation()
    {
        AnimationMN.d_Instance.EnemyAnimUpdate_Dead();
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(DeadProperties());
    }

    protected IEnumerator DeadProperties()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.gravityScale = 2;
        GetComponent<GroundEnemies>().enabled = false;
        yield return new WaitForSeconds(1f);
        enemiesPool.SetEnemiesInactive(enemy);
    }
}
