using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 14f;
    private Rigidbody2D rb;
    private bool IsAttacking;

    private bool isGrounded;
    Animator Animator;
    public GemManager gemManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Move player forward continuously
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        Animator.SetFloat("Xvelocity", rb.linearVelocity.x);
        Animator.SetFloat("Yvelocity", rb.linearVelocity.y);


        // Jump only if grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Animator.SetBool("IsJumping", !isGrounded);

        }

        Attack();

    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            IsAttacking = true;
            Animator.SetTrigger("Attack");
              // IsAttacking = false;
        }    
    }
    void EndAttack()
    {
        IsAttacking = false;
    }

    public void DeadAnimation()
    {
        Animator.SetTrigger("IsDead");
        this.enabled = false;
 }


    // All the collistions
    void HandleGemCollision(Collider2D collision)
{

        gemManager.AddScore(1);
        Destroy(collision.gameObject);
        // Debug.Log("Gem collected!");
    
}
    void HandleEnemyCollision(Collider2D collision)
    {
        
        if (IsAttacking == false)
        {
            GetComponent<HealthManage>().TakeDamage(30);
        }
        Destroy(collision.gameObject);
    }
    void HandleCherryCollision(Collider2D collision)
    {
        GetComponent<HealthManage>().IncreaseHealth(30);
        Destroy(collision.gameObject);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gem"))
        {
            HandleGemCollision(collision);
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            HandleEnemyCollision(collision);

        }

        else if (collision.gameObject.CompareTag("cherry")) HandleCherryCollision(collision); 

}

}
