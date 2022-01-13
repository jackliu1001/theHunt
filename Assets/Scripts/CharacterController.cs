using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController : PhysicsObject
{
    [SerializeField] private float horizontalSpeed = 7f;
    [SerializeField] protected float sprintMultiplier;
    [SerializeField] protected float crouchMultiplier;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float dashForce;
    [SerializeField] protected float dashCooldown;
    [SerializeField] [Range(0, 1)] protected float colliderMultiplier;
    [HideInInspector] public bool isFacingLeft;
    [HideInInspector] public bool isCrouching;
    [HideInInspector] public bool isDodging;

    private BoxCollider2D player;
    private Vector2 originalCollider;
    private Vector2 crouchCollider;
    private Vector2 originalOffset;
    private Vector2 crouchOffset;

    protected float currentSpeed;
    protected bool isJumping;
    private Rigidbody2D rb;
    private Vector2 facingLeft;
    protected Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        anim = GetComponent<Animator>();
        player = GetComponent<BoxCollider2D>();
        originalCollider = player.size;
        crouchCollider = new Vector2(player.size.x, player.size.y * colliderMultiplier);
        originalOffset = player.offset;
        crouchOffset = new Vector2(player.offset.x, player.offset.y*colliderMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetMouseButtonDown(0)) anim.SetTrigger("Attack");
        movement();
        crouch();
        checkDirection();
    }

    protected virtual void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        currentSpeed = horizontal * horizontalSpeed;
        jump();
        sprint();
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        if (currentSpeed != 0)
            anim.SetBool("Moving", true);
        else
            anim.SetBool("Moving", false);
        anim.SetFloat("CurrentSpeed", currentSpeed);
    }

    void jump()
    {
        anim.SetBool("Grounded", isGrounded);
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (isJumping && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, 0);
            else
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        anim.SetFloat("VerticalSpeed", rb.velocity.y);
    }

    protected void checkDirection()
    {
        if (rb.velocity.x > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            flip();
        }
        if(rb.velocity.x < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            flip();
        }
    }

    void flip()
    {
        if (isFacingLeft)
            transform.localScale = facingLeft;
        else
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    void sprint()
    {
        if (isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = currentSpeed * sprintMultiplier;
        }
    }
    void crouch()
    {
        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            isCrouching = true;
            anim.SetBool("Crouch", true);
            player.size = crouchCollider;
            player.offset = crouchOffset;
            currentSpeed *= crouchMultiplier;
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        }
        else if (isCrouching && hasHeadroom){
            //To do
            //Add platform and prevent raising up while under

            StartCoroutine(CrouchDisabled());
        }

    }

    protected IEnumerator CrouchDisabled()
    {
        player.offset = originalOffset;
        yield return new WaitForSeconds(0.01f);
        player.size = originalCollider;
        yield return new WaitForSeconds(0.05f);
        isCrouching = false;
        anim.SetBool("Crouch", false);
    }

    void dash()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            
        }
    }

    public void TakeDamage()
    {

    }
}
