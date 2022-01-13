using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    protected EnemyCharacter enemyCharacter;
    protected Rigidbody2D rb;

    private void Start()
    {
        Initialization();
    }

    protected virtual void Initialization()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyCharacter = GetComponent<EnemyCharacter>();
    }

    protected virtual bool CollisionCheck(Vector2 direction, float distance, LayerMask mask)
    { 
        Collider2D col = GetComponent<Collider2D>();
        return CollisionCheck(col, direction, distance, mask);
    }

    protected virtual bool CollisionCheck(Collider2D col, Vector2 direction, float distance, LayerMask mask)
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        
        int numofhits = col.Cast(direction, hits, distance);
        for (int i = 0; i < numofhits; i++)
        {
            if ((1 << hits[i].collider.gameObject.layer & mask) != 0)
                return true;
        }
        return false;
    }
}
