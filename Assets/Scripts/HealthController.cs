using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected Animator anim;
    public int currentHealth;
    [SerializeField] GameObject controller;

    public Healthbar healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        hit();
        controller.SendMessage("Took some damage");
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            death();
        }
    }

    public virtual void TakeDamage(int damage)
    {
        takeDamage(damage);
    }

    void death()
    {
        anim.SetTrigger("Death");
    }
    
    void hit()
    {
        anim.SetTrigger("Hit");
    }
}
