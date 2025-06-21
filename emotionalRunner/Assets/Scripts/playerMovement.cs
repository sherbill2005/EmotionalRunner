using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 14f;
    private Rigidbody2D rb;
    private bool IsAttacking;

    private bool isGrounded;
    Animator Animator;
    public GemManager gemManager;
    Controls controls;
    


    void Awake()
    {
        controls = new Controls();
        controls.PS4.Attack.performed += ctx => Attack();
        controls.PS4.Jump.performed += ctx => Jump();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        
    }
    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Update()
    {
        // Move player forward continuously
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        Animator.SetFloat("Xvelocity", rb.linearVelocity.x);
        Animator.SetFloat("Yvelocity", rb.linearVelocity.y);


        // Jump();
        
        // Attack();

    }
    void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Animator.SetBool("IsJumping", !isGrounded);
        }
    }
    void Attack(){
            IsAttacking = true;
            Animator.SetTrigger("Attack");
            SFXscript.instance.PlaySound(SFXscript.instance.attackClip);
        
    }
    void EndAttack()
    {
        IsAttacking = false;
    }

    public void DeadAnimation()
    {
        Animator.SetTrigger("IsDead");
        this.enabled = false;
        SFXscript.instance.PlaySound(SFXscript.instance.deathClip);
 }


    // All the collistions
    void HandleGemCollision(Collider2D collision)
    {

        gemManager.AddScore(1);
        PlayerStats.instance.ADDGems();
        Destroy(collision.gameObject);
        SFXscript.instance.PlaySound(SFXscript.instance.gemPickupClip);
        // Debug.Log("Gem collected!");

    }
    void HandleEnemyCollision(Collider2D collision)
    {

        if (IsAttacking == false)
        {
            GetComponent<HealthManage>().TakeDamage(30);
            EmotionManager.instance.setemotion(EmotionManager.Emotion.Angry);
            
            
            SFXscript.instance.PlaySound(SFXscript.instance.hurtClip);
        }
        else
        {
            PlayerStats.instance.ADDKills();
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
