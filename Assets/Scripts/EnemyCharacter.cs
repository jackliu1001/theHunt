using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [HideInInspector] public bool facingLeft;
    protected Rigidbody2D rb;
    protected Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    protected virtual void Initialization()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    protected virtual bool CollisionCheck(Vector2 direction, float distance, LayerMask mask)
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        int numofhits = col.Cast(direction, hits, mask);
        for(int i=0; i<numofhits; i++)
        {
            if ((1 << hits[i].collider.gameObject.layer & mask) != 0)
                return true;
        }
        return false;
    }
}
