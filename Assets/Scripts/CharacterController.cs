using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : PhysicsObject
{
    [SerializeField] private float horizontalSpeed = 7f;
    [SerializeField] protected float sprintMultiplier;
    [SerializeField] protected float jumpForce;
    [HideInInspector] public bool isFacingLeft;

    protected float currentSpeed;
    private bool isJumping;
    private Rigidbody2D rb;
    private Vector2 facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        checkDirection();
    }

    void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        currentSpeed = horizontal * horizontalSpeed;
        jump();
        sprint();
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    void jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
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
        if(Input.GetKey(KeyCode.LeftShift))
            currentSpeed = currentSpeed * sprintMultiplier;
    }
}
