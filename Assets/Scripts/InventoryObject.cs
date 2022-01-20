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
            FindObjectOfType<GameHandler>().playerInventory.AddInventoryItem(inventoryItem);
            DestroyInventoryObject();
        }
    }

    private void DestroyInventoryObject()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(!inventoryChecked && FindObjectOfType<GameHandler>())
        {
            if (FindObjectOfType<GameHandler>().playerInventory.HasInventoryItem(inventoryItem))
                DestroyInventoryObject();
        }
    }
}
