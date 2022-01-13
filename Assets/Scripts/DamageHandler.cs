using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] int damage;
    public virtual int getDamage()
    {
        return damage;
    }
}
