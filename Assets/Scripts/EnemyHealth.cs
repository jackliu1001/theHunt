using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthController
{
    [SerializeField] protected bool isInterruptable;
    [SerializeField] public BoxCollider2D takeDamageCollider;
    // Start is called before the first frame update
    private void Update()
    {
        if (currentHealth <= 0)
            death();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if(isInterruptable)
            hit();
    }

    void hit()
    {
        anim.SetTrigger("Hit");
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.5f);
    }
    private void death()
    {
        anim.SetTrigger("Death");
        //damageCollider.enabled = false;
        takeDamageCollider.enabled = false;
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DamageHandler>())
        {
            TakeDamage(collision.GetComponent<DamageHandler>().getDamage());
        }
    }

}
