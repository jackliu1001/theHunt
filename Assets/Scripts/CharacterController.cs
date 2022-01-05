using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] protected float jumpForce;
    [HideInInspector] public bool isGrouded;

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
        rb.velocity = new Vector2(horizontal * horizontalSpeed, rb.velocity.y);
        //if(Input.GetKeyDown(KeyCode.Space))
        //rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        jumpPressed();
    }

    protected void FixedUpdate()
    {
        IsJumping();
    }

    bool jumpPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            return true;
        }
        else
            return false;
    }

    void IsJumping()
    {
        if(isJumping)
            rb.AddForce(Vector2.up * jumpForce);
    }

    protected bool collisionCheck()
    {

    }
}
