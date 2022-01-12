using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AIManager
{
    [SerializeField] protected enum MovementType { Normal }
    [SerializeField] protected MovementType type;
    [SerializeField] protected float timeTillMaxSpeed;
    [SerializeField] protected bool spawnFacingLeft;
    [SerializeField] protected bool turnAroundOnCollision;
    [SerializeField] protected bool avoidFalling;
    [SerializeField] protected float maxSpeed;
    [SerializeField] LayerMask collidersToTurn;

    private bool spawning = true;
    private float direction;
    private float acceleration;
    private float runTime;
    protected float currentSpeed;

    protected override void Initialization()
    {
        base.Initialization();
        if(spawnFacingLeft)
        {
            enemyCharacter.facingLeft = true;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        Invoke("Spawning", 0.01f);
    }

    protected virtual void FixedUpdate()
    {
        movement();
    }

    protected void movement()
    {
        if (!enemyCharacter.facingLeft)
        {
            direction = 1;
            if (CollisionCheck(Vector2.right, 0.5f, collidersToTurn) && turnAroundOnCollision && !spawning)
            {
                enemyCharacter.facingLeft = true;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
        else
        {
            direction = -1;
            if (CollisionCheck(Vector2.left, 0.5f, collidersToTurn) && turnAroundOnCollision && !spawning)
            {
                enemyCharacter.facingLeft = false;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
        acceleration = maxSpeed / timeTillMaxSpeed;
        runTime += Time.deltaTime;
        currentSpeed = acceleration * direction * runTime;
        checkSpeed();
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    protected void checkSpeed()
    {
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
        else if (currentSpeed < -maxSpeed)
            currentSpeed = -maxSpeed;
    }

    protected virtual void Spawning()
    {
        spawning = false;
    }
}
