using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    
    protected Rigidbody2D rb;
    protected Collider2D col;
    protected Animator anim;

    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    private void Update()
    {
        anim.SetFloat("TargetDistance", Vector2.Distance(transform.position, target.position));
    }

    protected virtual void Initialization()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void takeDamage()
    {

    }
    
}
