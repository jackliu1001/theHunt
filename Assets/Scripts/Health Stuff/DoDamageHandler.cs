using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageHandler : MonoBehaviour
{
    [SerializeField] int damage;
    
    public virtual int GetDamage()
    {
        return damage;
    }
}
