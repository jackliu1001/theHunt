using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    protected bool isGrounded { get { return grounded(); } }
    [SerializeField] protected LayerMask groundMask;
    virtual protected bool grounded()
    {
        RaycastHit2D hit = rayCast(transform.position, Vector2.down, 1.25f + 0.1f, groundMask);
        if (hit.collider) return true;

        return false;
    }

    protected RaycastHit2D rayCast(Vector2 point, Vector2 direction, float distance, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast(point, direction, distance, mask);
        return hit;
    }
}
