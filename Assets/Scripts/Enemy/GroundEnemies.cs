using System.Collections;
using UnityEngine;

public abstract class GroundEnemies : Enemy
{
    private const string DEAD_TRIG = "Dead";
    [Header("Checking Collision")]
    [SerializeField] private Transform checkPointCollision;
    [SerializeField] private Transform checkPointGround;
    [SerializeField] Vector2 collisionCheckSize;
    [SerializeField] LayerMask collisionLayerMask;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] float groundCheckRadius;

    [Header("Other")]
    [SerializeField] Animator enemy_aim;
    [SerializeField] Transform hitbox;
    protected override void Awake()
    {
        base.Awake();
        enemy_aim = GetComponent<Animator>();
    }
    
    protected virtual void Update()
    {
        CollisionCheck();
    }

    bool IsCollision()
    {
        return Physics2D.OverlapBox(checkPointCollision.position, collisionCheckSize, 0, collisionLayerMask);
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(checkPointGround.position, groundCheckRadius, groundLayerMask);
    }
    protected void CollisionCheck()
    {
        if (IsCollision() || !IsGrounded())
        {
            direction *= -1;
            transform.Rotate(0, 180, 0);
        }
    }

    protected virtual IEnumerator DeadPropertiesSettings()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        hitbox.GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponentInChildren<GroundEnemies>().enabled = false;
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
        DeadAnimation(enemy_aim, DEAD_TRIG);
        rb.gravityScale = 2;
        yield return new WaitForSeconds(1f);
        DeadEnemiesPooling.d_Instance.ReturnEnemiesToPool(enemiesPrefabs);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(checkPointCollision.position, collisionCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(checkPointGround.position, groundCheckRadius);
    }
}
