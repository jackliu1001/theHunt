using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    [SerializeField] InventoryItem inventoryItem;
    bool inventoryChecked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameHandler>().PlayerInventory.AddInventoryItem(inventoryItem);
            DestoryInventoryObject();
        }
    }

    private void Update()
    {
        if (!inventoryChecked && FindObjectOfType<GameHandler>())
        {
            if (FindObjectOfType<GameHandler>().PlayerInventory.HasInventoryItem(inventoryItem))
                DestoryInventoryObject();
        }
    }

    private void DestoryInventoryObject()
    {
        Destroy(gameObject);
    }
}
