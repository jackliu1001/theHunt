using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthController
{
    public Healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.setMaxHealth(maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthbar.setHealth(currentHealth);
        hit();
    }

    void hit()
    {
        anim.SetTrigger("Hit");
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        damageCollider.enabled = false;
        yield return new WaitForSeconds(1);
        damageCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DamageHandler>())
        {
            Debug.Log("Damage");
            TakeDamage(collision.GetComponent<DamageHandler>().getDamage());
        }
    }

    public void respawn()
    {
        currentHealth = maxHealth;
        healthbar.setHealth(currentHealth);
        damageCollider.enabled = true;
    }
}
