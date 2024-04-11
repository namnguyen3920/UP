
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public delegate void UpdateAnimation();

public abstract class PlayerController : Singleton_Mono_Method<PlayerController>
{

    protected Rigidbody2D rb;
    private const string IS_GROUND = "isGround";
    private const string IS_JUMPING = "isJumping";
    private const string IS_WALLSLIDING = "isWallSliding";
    private const string IS_DEAD = "Death";

    [Header("Ground Checking Collision")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;

    [Header("Wall Checking Collision")]
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Transform onWallCheckPoint;
    [SerializeField] Vector2 onWallCheckSize;
    [SerializeField] float wallCheckRadius;

    [Header("Wall checking")]
    [SerializeField] protected bool onWall;
    [SerializeField] protected bool isTouchingWall;
    [SerializeField] protected bool isWallSliding;

    [Header("Ground checking")]
    [SerializeField] protected bool grounded;
    [SerializeField] protected bool isJumping;
    [SerializeField] protected bool canJump;

    [Header("Status checking")]
    [SerializeField] protected bool isMoving;
    [SerializeField] protected bool isDead;

    public event UpdateAnimation AnimateUpdate;
    Animator anim;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        AnimateUpdate?.Invoke();
        Inputs();
        CheckWorld();
        AnimationBoolControl();
        AnimationFloatControl();
    }

    protected virtual void FixedUpdate()
    {
        AnimateUpdate?.Invoke();
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        isDead = true;
        AnimationTriggerControl();
    }

    public void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.Space) && isWallSliding)
        {
            SoundFXCtrl.d_Instance.PlayFXSound(transform, 0.5f);
            canJump = true;
            isJumping = true;
        }
    }

    public void CheckWorld()
    {
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(wallCheckPoint.position, wallCheckRadius, wallLayer);
        onWall = Physics2D.OverlapBox(onWallCheckPoint.position, onWallCheckSize, 0, wallLayer);
    }
    private void AnimationBoolControl()
    {
        anim.SetBool(IS_GROUND, IsGround);
        anim.SetBool(IS_JUMPING, IsJumping());
        anim.SetBool(IS_WALLSLIDING, IsWallSliding());
    }

    private void AnimationFloatControl()
    {
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void AnimationTriggerControl()
    {
        anim.SetTrigger(IS_DEAD);
    }
    #region
    public bool IsGround
    {
        get
        {
            if (VelocityY == 0 && grounded) return true;
            else return false;
        }
    }
    public bool IsJumping() { return isJumping; }
    public bool IsWallSliding() { return isWallSliding; }
    public bool IsTouchingWall() { return isTouchingWall; }
    public float VelocityY => rb.velocity.y;
    #endregion


    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Traps"))
        {
            Die();
        }
    }
    private void OnDrawGizmosSelected()
    {
        /*Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);*/
        Gizmos.color = Color.green;
        Gizmos.DrawCube(onWallCheckPoint.position, onWallCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(wallCheckPoint.position, wallCheckRadius);
    }
}
