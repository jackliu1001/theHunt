using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/Inventory/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] bool canLedgeClimb;
    [SerializeField] bool canDodge;
    [SerializeField] bool canFallAttack;

    public bool CanLedgeClimb { get { return canLedgeClimb; } }
    public bool CanDodge { get { return canDodge; } }
    public bool CanFallAttack { get { return canFallAttack; } }
}
