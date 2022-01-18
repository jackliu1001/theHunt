using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    public int currentHealth;
    public Animator anim;
    public BoxCollider2D damageCollider;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public virtual void TakeDamage(int damage)
    {
        takeDamage(damage);
    }

}
