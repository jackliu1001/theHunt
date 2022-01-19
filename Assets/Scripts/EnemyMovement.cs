using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AIManager
{
    public enum MovementType { Normal }
    [SerializeField] protected MovementType type;

    public enum MovementStates { idle, follow, move, hit, dead};
    private MovementStates movementState;
    public MovementStates MovementState { set { movementState = value; } }

    [SerializeField] protected bool facingLeft;
    [SerializeField] protected float timeTillMaxSpeed;
    [SerializeField] protected bool spawnFacingLeft;
    [SerializeField] protected bool turnAroundOnCollision;
    [SerializeField] protected bool avoidFalling;
    [SerializeField] protected float maxSpeed;
    [SerializeField] LayerMask collidersToTurn;
    public SpriteRenderer spriteRenderer;

    private bool spawning = true;
    private int direction;
    private float acceleration;
    private float runTime;
    protected float currentSpeed;

    private Transform target;
    [SerializeField] private float distance;
    public float Distance { get { return distance; } }

    protected override void Initialization()
    {
        base.Initialization();
        if(spawnFacingLeft)
        {
            facingLeft = true;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        Invoke("Spawning", 0.01f);
    }

    protected virtual void FixedUpdate()
    {
        switch (movementState)
        {
            case MovementStates.move:
                move();
                break;
            case MovementStates.follow:
                follow();
                break;
            case MovementStates.idle:
                idle();
                break;
            case MovementStates.hit:
                hit();
                break;
            case MovementStates.dead:
                dead();
                break;
        }
        
    }
    public void idleStart()
    {
        movementState = MovementStates.idle;
    }
    protected void idle()
    {

    }
    public void followStart()
    {
        movementState = MovementStates.follow;
    }
    protected void follow()
    {
        if (!target) target = GameObject.FindGameObjectWithTag("Player").transform;
        int direction = transform.position.x < target.position.x ? 1 : -1;
        if(direction != this.direction)
        {
            changeDirection();
            this.direction = direction;
        }
        movement();
    }
    public void moveStart()
    {
        distance = 0;
        movementState = MovementStates.move;
    }
    private void move()
    {
        if (!facingLeft)
        {
            direction = 1;
            if (CollisionCheck(Vector2.right, 0.5f, collidersToTurn) && turnAroundOnCollision && !spawning)
            {
                changeDirection();
            }
        }
        else
        {
            direction = -1;
            if (CollisionCheck(Vector2.left, 0.5f, collidersToTurn) && turnAroundOnCollision && !spawning)
            {
                changeDirection();
            }
        }
        movement();
    }

    private void hit()
    {

    }

    public void hitStart()
    {
        currentSpeed = 0;
        acceleration = 0;
        movementState = MovementStates.hit;
    }

    private void dead()
    {
        //this.gameObject.SetActive(false);

    }

    public void deadStart()
    {
        movementState = MovementStates.dead;
    }


    void changeDirection()
    {
        facingLeft = !facingLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    protected void movement()
    {
        
        acceleration = maxSpeed / timeTillMaxSpeed;
        runTime += Time.deltaTime;
        currentSpeed = Mathf.Clamp(acceleration * direction * runTime, -maxSpeed, maxSpeed);
        distance += Mathf.Abs(currentSpeed * Time.deltaTime);
        
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    protected virtual void Spawning()
    {
        spawning = false;
    }
}
