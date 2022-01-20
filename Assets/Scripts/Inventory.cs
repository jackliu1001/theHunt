using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] List<InventoryItem> inventory = new List<InventoryItem>();

    public void AddInventoryItem(InventoryItem item)
    {
        inventory.Add(item);
    }

    public bool CanLedgeClimb()
    {
        foreach(InventoryItem item in inventory)
            if (item.CanLedgeClimb)
                return true;
        return false;
    }
    public bool CanDodge()
    {
        foreach (InventoryItem item in inventory)
            if (item.CanDodge)
                return true;
        return false;
    }
    public bool CanFallAttack()
    {
        foreach (InventoryItem item in inventory)
            if (item.CanFallAttack)
                return true;
        return false;
    }

    public void ClearInventory()
    {
        inventory.Clear();
    }

    public bool HasInventoryItem(InventoryItem item)
    {
        foreach (InventoryItem inventoryItem in inventory)
            if (item == inventoryItem)
                return true;
        return false;
    }
}
