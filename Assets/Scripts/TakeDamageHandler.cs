using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageHandler : MonoBehaviour
{
    [SerializeField] PlayerHealth healthController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DamageHandler>())
        {
            Debug.Log("Damage");
            healthController.TakeDamage(collision.GetComponent<DamageHandler>().getDamage());
        }
    }
}
