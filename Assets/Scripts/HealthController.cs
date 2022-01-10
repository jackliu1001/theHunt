using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    public int currentHealth;
    public Healthbar healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            takeDamage(20);
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }
}
