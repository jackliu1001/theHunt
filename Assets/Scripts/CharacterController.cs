using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : PhysicsObject
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] protected float jumpForce;
    

    private bool isJumping;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Jump");
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb.velocity = new Vector2(horizontal * horizontalSpeed, jumpForce);
        }else if (isJumping && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(horizontal * horizontalSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector2(horizontal * horizontalSpeed, rb.velocity.y);
            }
            
        }
        else
        {
            rb.velocity = new Vector2(horizontal * horizontalSpeed, rb.velocity.y);
        }
        

        

    }

  

    

    



}
