using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : EnemyMovement
{
    protected int direction;
    private float acceleration;
    private float runTime;
    protected float currentSpeed;
    override public void idleStart()
    {
        movementState = MovementStates.idle;
    }
    override protected void idle()
    {

    }
    override public void followStart()
    {
        movementState = MovementStates.follow;
    }
    override protected void follow()
    {
        if (!target) target = GameObject.FindGameObjectWithTag("Player").transform;
        int direction = transform.position.x < target.position.x ? 1 : -1;
        if (direction != this.direction)
        {
            changeDirection();
            this.direction = direction;
        }
        movement();
    }
    override public void moveStart()
    {
        distance = 0;
        movementState = MovementStates.move;
    }
    override protected void move()
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

    override protected void hit()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    override public void hitStart()
    {
        currentSpeed = 0;
        acceleration = 0;
        movementState = MovementStates.hit;
    }

    override protected void dead()
    {
        //this.gameObject.SetActive(false);
    }

    override public void deadStart()
    {
        movementState = MovementStates.dead;
    }

    override protected void movement()
    {

        acceleration = maxSpeed / timeTillMaxSpeed;
        runTime += Time.deltaTime;
        currentSpeed = Mathf.Clamp(acceleration * direction * runTime, -maxSpeed, maxSpeed);
        distance += Mathf.Abs(currentSpeed * Time.deltaTime);

        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    void changeDirection()
    {
        facingLeft = !facingLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
