using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemDisplaysManager : MonoBehaviour {

    public List<InventoryItemDisplay> itemsDisplayList;
    public PlayerInvetory playerInventory;
    

    public void AddItem(ItemScript item)
    {
        int count = playerInventory.GetItemCount();
        itemsDisplayList[count].SetItem(item);
        itemsDisplayList[count].gameObject.SetActive(true);
        itemsDisplayList[count].SetItemCount(count);
    }

    public void RemoveItem(int count)
    {
        itemsDisplayList[count].ClearInventoryItemDisplay();
        itemsDisplayList[count].gameObject.SetActive(false);
    }

}
