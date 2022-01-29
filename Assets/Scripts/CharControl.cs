using UnityEngine;

public class CharControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Animator animator;
    public AudioSource jumpSound;

    private float speed = 3f, jumpForce = 150f, checkRad = 0.5f, jumpCharge = 1f;
    private bool isGrounded;

    private SpriteRenderer sr;

    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {

        if (StartGame.isStart)
        {
            Movement();
            Jump();
            JumpCharge();
        }                
    }

    void Movement()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0)
        {
            sr.flipX = false;
        }

        else if (move < 0)
        {
            sr.flipX = true;
        }

        if (move > 0 || move < 0)
        {
            animator.SetTrigger("isRunning");
        }

        else
        {
            animator.ResetTrigger("isRunning");
        }
    }
    
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRad, whatIsGround);

        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce * jumpCharge));
            jumpCharge = 1f;
            animator.Play("Jump");
            jumpSound.Play();                
        }
    }

    void JumpCharge()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jumpCharge += Time.deltaTime;
            animator.Play("JumpCharge");
        }            
    }     
}
