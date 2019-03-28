using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private ItemScript item;
    private int itemCount;
    public CameraManager cameraManager;
    public SpriteRenderer itemViewDetailSpriteRenderer;
    public EquipItemButton equipItemButton;
    public Text itemNameText;
    public Text defenseText;
    public Text meeleText;
    public Text rangedText;
    public Text hungerText;
    public Text thirstText;
    public Text weightText;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    public void SetItem(ItemScript item)
    {
        if (spriteRenderer == null || cameraManager == null || itemViewDetailSpriteRenderer == null || equipItemButton == null) 
        {
            print("Error in InventoryItemDisplay SetItem34\n");
            return;
        }

        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public void SetItemCount(int count) { itemCount = count; }
    public int GetItemCount() { return itemCount; }
    public bool GetIsEquipable() { return item.GetIsEquipable(); }
    public ItemScript GetItem() { return item; }

    private void OnMouseDown()
    {
        if(itemViewDetailSpriteRenderer == null || cameraManager == null || spriteRenderer == null || item == null)
        {
            print("Error in InventoryItemDisplay OnMouseDown 43\n");
            return;
        }
        itemViewDetailSpriteRenderer.sprite = item.GetSprite();
        itemNameText.text = "Item Name: " + item.GetItemName();
        defenseText.text = "Defense: " + item.GetDefenseBoost().ToString();
        meeleText.text = "Meele Attack: " + item.GetMeeleBoost().ToString();
        rangedText.text = "Ranged Attack: " + item.GetRangedBoost().ToString();
        hungerText.text = "Hunger: " + item.GetHungerBoost().ToString();
        thirstText.text = "Thirst: " + item.GetThirstBoost().ToString();
        weightText.text = "Weight: " + item.GetItemWeight().ToString();
        cameraManager.SendMessage("ActivateItemViewDetail");
        equipItemButton.SetInventoryItemDisplay(this);
    }

    public void ClearInventoryItemDisplay()
    {
        item = null;
        itemNameText.text = "";
        defenseText.text = "";
        meeleText.text = "";
        rangedText.text = "";
        hungerText.text = "";
        thirstText.text = "";
        weightText.text = "";

    }


}
