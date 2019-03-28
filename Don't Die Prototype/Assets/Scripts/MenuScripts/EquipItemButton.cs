using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemButton : MonoBehaviour {

    private InventoryItemDisplay inventoryItemDisplay;
    public InventoryItemDisplaysManager inventoryItemDisplaysManager;
    public PlayerInvetory playerInvetory;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (playerInvetory == null || inventoryItemDisplay == null)
        {
            print("Error in EquipItemButton OnMouseDown25\n");
            return;
        }
        playerInvetory.EquipItem(inventoryItemDisplay.GetItem());
        inventoryItemDisplaysManager.RemoveItem(inventoryItemDisplay.GetItemCount());

    }

    public void SetInventoryItemDisplay(InventoryItemDisplay inventoryItemDisplay)
    {
        if (inventoryItemDisplaysManager == null)
        {
            print("Error on EquipItemButton SetInventoryItemDIsplay 32\n");
            return;
        }

        this.inventoryItemDisplay = inventoryItemDisplay;
    }
}
