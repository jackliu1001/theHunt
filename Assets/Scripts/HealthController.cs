using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
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
        controller.SendMessage("");
    }

    public virtual void TakeDamage(int damage)
    {
        takeDamage(damage);
    }
}
