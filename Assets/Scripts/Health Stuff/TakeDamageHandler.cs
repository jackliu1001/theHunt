using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageHandler : MonoBehaviour
{
    [SerializeField] HealthController healthController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DoDamageHandler>())
        {
            healthController.TakeDamage(collision.GetComponent<DoDamageHandler>().GetDamage());
        }
    }
}
