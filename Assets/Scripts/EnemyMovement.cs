using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : AIManager
{
    public enum MovementType { Normal }
    [SerializeField] protected MovementType type;

    public enum MovementStates { idle, follow, move, hit, dead, attack};
    protected MovementStates movementState;
    public MovementStates MovementState { set { movementState = value; } }

    [SerializeField] protected bool facingLeft;
    [SerializeField] protected float timeTillMaxSpeed;
    [SerializeField] protected bool spawnFacingLeft;
    [SerializeField] protected bool turnAroundOnCollision;
    [SerializeField] protected bool avoidFalling;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected LayerMask collidersToTurn;
    public SpriteRenderer spriteRenderer;

    protected bool spawning = true;

    protected Transform target;
    protected float distance;
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
            case MovementStates.attack:
                attack();
                break;
        }
        
    }
    public abstract void idleStart();
    protected abstract void idle();
    public abstract void followStart();
    protected abstract void follow();
    public abstract void moveStart();
    protected abstract void move();
    protected abstract void hit();
    public abstract void hitStart();
    protected abstract void dead();
    public abstract void deadStart();
    protected abstract void movement();
    protected abstract void attack();
    public abstract void attackStart();
    protected virtual void Spawning()
    {
        spawning = false;
    }
}
